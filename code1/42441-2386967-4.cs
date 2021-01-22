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
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            SeleniumProcess.Stop();
            Assert.AreEqual("", _verificationErrors.ToString());
        }
        #endregion
