    [TestClass]
    public class TestUnittestRunning
    {
        [TestMethod]
        public void UnitTestRunningTest()
        {
            Assert.IsTrue(MyTools.UnitTestMode);
        }
    }
