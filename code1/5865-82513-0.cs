    public abstract class TestBase
    {
        protected int foo = 0;
        [TestMethod]
        public void TestUnderTen()
        {
            Assert.IsTrue(foo < 10);
        }
        [TestMethod]
        public void TestOver2()
        {
            Assert.IsTrue(foo > 2);
        }
    }
    [TestClass]
    public class TestA: TestBase
    {
        public TestA()
        {
            foo = 4;
        }
    }
    [TestClass]
    public class TestB: TestBase
    {
        public TestB()
        {
            foo = 6;
        }
    }
