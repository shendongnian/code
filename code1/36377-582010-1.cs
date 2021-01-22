    internal class TestClient : PFServer2ServerClientBase<ITest>, ITest
    {
        public string TestMethod(int value)
        {
            return base.Channel.TestMethod(value);
        }
    }
