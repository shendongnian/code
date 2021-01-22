    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SimpleCalculator;
    using NUnit.Framework;
    
    namespace CalculatorTest
    {
        [TestFixture]
        public class Class1
        {
            public Calculator _calculator;
            [TestFixtureSetUp]
            public void Initialize()
            {
                _calculator = new Calculator();
            }
            [Test]
            public void DivideTest()
            {
                int a = 10;
                int b = 2;
                int expectedValue = a / b;
                int actualvalue = _calculator.Divide(a, b);
                Assert.AreEqual(expectedValue, actualvalue,"Failure");
            
            }
        }
    }
