    using System.Text;
    using NUnit.Framework;
    
    namespace Test.SampleTests
    {
        [TestFixture]
        public class CustomerTestClass
        {
            [TestCase(1, true)] // valid customer
            [TestCase(2, true)] // valid customer
            [TestCase(1123123123132, false)] // invlaid customer
            public void IsValidCustomerTest(int customerId, bool isValid)
            {
                Assert.AreEqual(_service.ValidateCust(customerId), isValid);
            }
        }
    }
