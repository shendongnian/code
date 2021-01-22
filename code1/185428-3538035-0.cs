    public class IntegrationTestsBase
    {
        private TransactionScope scope;
        [TestInitialize]
        public void Initialize()
        {
            this.scope = new TransactionScope();
        }
        [TestCleanup]
        public void TestCleanup()
        {
            this.scope.Dispose();
        }
    }
