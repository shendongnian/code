    [SetUpFixture]
    public class UnitTestSuiteSetupTeardown
    {
        [SetUp]
        public void Setup()
        {
            LogFactory.Configure();
        }
        [TearDown]
        public void Teardown()
        {
            //Teardown stuff...
        }
    }
