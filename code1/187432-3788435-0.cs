    public class TestClass
    {
        public virtual void TestFixtureSetUp()
        {
            // environment independent code...
        }
        [Test]
        public void Test1() { Console.WriteLine("Test1 pass.");  }
        // More Environment independent tests...
    }
    [TestFixture]
    public class BrowserFixture : TestClass
    {
        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();
            // environment dependent code...
        }
    }
    [TestFixture]
    public class GUIFixture : TestClass
    {
        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();
            // environment dependent code...
        }
    }
