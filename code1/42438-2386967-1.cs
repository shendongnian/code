        [SetUp]
        public void SetupTest()
        {
            SeleniumProcess.Start();
        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _selenium.Stop();
            }
