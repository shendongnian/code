     [TestFixture]
        public class when_getting_value_of_enum
        {
            [Test]
            public void should_get_the_value_as_string()
            {
                Assert.AreEqual("AzamSharpBlogTestDatabase",DatabaseEnvironment.Test.GetValueAsString());  
            }
        }
 
