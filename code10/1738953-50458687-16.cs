    class ApplicationStub : IApplication
    {
        public string TestResult { get; set; }  //Doesn't exist in system under test
        public void SomeMethod(string input)
        {
            this.TestResult = input;
        }
    }
