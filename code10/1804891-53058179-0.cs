    public interface ITest
    {
        void TestMethod();
    }
    public static class TestFactory
    {
        private class Test: ITest
        {
            public void TestMethod() { }
        }
        public static ITest CreateTest()
        {
            return new Test();
        }
    }
