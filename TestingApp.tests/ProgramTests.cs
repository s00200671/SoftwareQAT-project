using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestingApp;

namespace TestingApp.tests
{
    [TestFixture]
    public class InsuranceServiceTests
    {
        static double ExpectedResult;

        static Program.InsuranceService insuranceService;

        [SetUp]
        public static void Init()
        {
            insuranceService = new Program.InsuranceService();
        }

        [Test]
        // under 18, female
        public void gender_age_1()
        {
            ExpectedResult = 0.0;
            double ActualResult = insuranceService.CalcPremium(10, "female");
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [Test]
        // 18, female
        public void gender_age_2()
        {
            ExpectedResult = 5.0;
            double ActualResult = insuranceService.CalcPremium(18, "female");
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [Test]
        // over 35 and 50, female
        public void gender_age_3()
        {
            // Initally premium set to 2.5 since they are female and over 36, then multiplied by 0.15 since they are over 50
            ExpectedResult = 0.375;
            double ActualResult = insuranceService.CalcPremium(50, "female");
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [Test]
        // under 18, male
        public void gender_age_4()
        {
            ExpectedResult = 0.0;
            double ActualResult = insuranceService.CalcPremium(10, "male");
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [Test]
        // between 18 and 35, male
        public void gender_age_5()
        {
            ExpectedResult = 6.0;
            double ActualResult = insuranceService.CalcPremium(18, "male");
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [Test]
        // over 35, male
        public void gender_age_6()
        {
            ExpectedResult = 5.0;
            double ActualResult = insuranceService.CalcPremium(36, "male");
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [Test]
        // over 50, other
        public void gender_age_7()
        {
            ExpectedResult = 0.0;
            double ActualResult = insuranceService.CalcPremium(51, "other");
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
