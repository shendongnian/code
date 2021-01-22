        private delegate void TestImplDelegate();
        private void RunTestWithExceptionLogging(TestImplDelegate testImpl)
        {
            try
            {
                testImpl();
            }
            catch (Exception e)
            {
                string message = e.Message; // don't warn about unused variables
                // do logging here
            }
        }
        [TestMethod]
        public void test1()
        {
            RunTestWithExceptionLogging(test1Impl);
        }
        private void test1Impl()
        {
            // test code goes here
            throw new Exception("This should get logged by the test wrapper.");
        }
        [TestMethod]
        public void test2()
        {
            RunTestWithExceptionLogging(test2Impl);
        }
        private void test2Impl()
        {
            // test code goes here
            throw new Exception("This should get logged by the test wrapper.");
        }
