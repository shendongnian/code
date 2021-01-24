    using System.Diagnostics;
    using NUnit.Framework;
    
    namespace Test
    {
        [SetUpFixture]
        public class SharedActions
        {
            [OneTimeSetUp]
            public void SharedSignIn()
            {
                Debug.WriteLine("Signed in.");
            }
    
            [OneTimeTearDown]
            public void SharedSignOut()
            {
                Debug.WriteLine("Signed out.");
            }
        }
    
        [TestFixture]
        public class FirstEndpointTests
        {
            [Test]
            public void FirstEndpointTest()
            {
                Debug.WriteLine("Test for Endpoint A");
            }
        }
    
        [TestFixture]
        public class SecondEndpointTests
        {
            [Test]
            public void SecondEndpointTest()
            {
                Debug.WriteLine("Test for Endpoint B");
            }
        }
    }
