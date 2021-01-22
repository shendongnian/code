    [TestFixture]
    public class DerivedTest : TestBase
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            
            File.AppendAllText("Out.txt", string.Format("TestFixtureSetUp From DerivedTest{0}", Environment.NewLine));
        }
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            File.AppendAllText("Out.txt", string.Format("TestFixtureTearDown Down From DerivedTest{0}", Environment.NewLine));
        }
        [SetUp]
        public void Setup()
        {
            File.AppendAllText("Out.txt", string.Format("Setup From DerivedTest{0}", Environment.NewLine));
        }
        [TearDown]
        public void Down()
        {
            File.AppendAllText("Out.txt", string.Format("TearDown From DerivedTest{0}", Environment.NewLine));
        }
        [Test]
        public void DoATest()
        {
            File.AppendAllText("Out.txt", string.Format("Did a Test{0}", Environment.NewLine));
        }
    }
    
