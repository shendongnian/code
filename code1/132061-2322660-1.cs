    public class UnitTestBase
    {
        protected abstract void PerFixtureSetUp();
        [TestFixtureSetUp]
        public void SetUpTestFixture()
        {
            PerFixtureSetUp();
        }
    }
    
    [TestFixture]
    public class SomeTestClass : UnitTestBase
    {
        protected override void PerFixtureSetUp()
        {
            
        }
    
        [Test]
        public void SomeTest()
        {
            //Some assertion
        }
    }
