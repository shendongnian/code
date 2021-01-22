    public class TestBase
    {
        [TestFixtureSetUp]
        public void BaseTestFixtureSetUp()
        {
            File.AppendAllText("Out.txt", string.Format("TestFixtureSetUp From TestBase{0}", Environment.NewLine));
        }
        [TestFixtureTearDown]
        public void BaseTestFixtureTearDown()
        {
            File.AppendAllText("Out.txt", string.Format("TestFixtureTearDown From TestBase{0}", Environment.NewLine));
        }
        [SetUp]
        public void BaseSetup()
        {
            File.AppendAllText("Out.txt", string.Format("Setup From TestBase{0}", Environment.NewLine));
        }
        [TearDown]
        public void TearDown()
        {
            File.AppendAllText("Out.txt", string.Format("TearDown From TestBase{0}", Environment.NewLine));
        }
    }
