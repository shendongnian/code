    class ApplicationStub : IApplication
    {
        public string Input { get; set; }  //Doesn't exist in system under test
        public void Foo(string input)
        {
            Input = input;
        }
    }
