    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() => Assert.IsTrue(true);
        [TestMethod]
        internal void TestMethod2() => Assert.IsTrue(false);
    }
