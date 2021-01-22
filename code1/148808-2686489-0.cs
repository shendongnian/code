        private TransactionScope transScope;
        #region Additional test attributes
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            transScope = new TransactionScope();
        }
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transScope.Dispose();
        }
