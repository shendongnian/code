    [SetUpFixture]
    public class UnitTestSuiteSetupTeardown
    {
        [SetUp]
        public void Setup()
        {
            log4net.Config.BasicConfigurator.Configure();
        }
        [TearDown]
        public void Teardown()
        {
            //Teardown stuff...
        }
    }
