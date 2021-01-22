    internal interface ITestRunner
    {
        void RunTest(object _param, object _expectedValue);
    }
    internal class TestRunner<T> : ITestRunner
    {
        public void RunTest(object _param, T _expectedValue)
        {
            T result = MakeGenericCall<T>();
            Assert.AreEqual(_expectedValue, result);
        }
        public void RunTest(object _param, object _expectedValue)
        {
            RunTest(_param, (T)_expectedValue);
        }
    }
