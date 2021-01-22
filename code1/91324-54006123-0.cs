        [OneTimeTearDown]
        public void AfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
               Console.WriteLine("FAILS");
            }
            else if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success))
            {
                Console.WriteLine("SUCESS");
            }
        }
