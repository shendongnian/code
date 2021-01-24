        [TestInitialize]
        public void BeforeEachTest()
        {
            testFixture = new TestFixture<TestStartup, Startup>();
            //this is my HttpClient variable
            client = testFixture.Client;
        }
