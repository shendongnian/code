    using NUnit.Framework;
    
    namespace My.Namespace
    {
        public class MyEntityTests
        {
            [SetUp]
            public void Setup()
            {
            }
    
            [TestFixture]
            public class MyComplexMethodTests : MyEntityTests
            {
                [Test]
                public void when_some_condition_than()
                {
                }
    
                [Test]
                public void when_some_other_condition_then()
                {
                }
            }
        }
    }
