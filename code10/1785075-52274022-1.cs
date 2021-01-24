    class SecondTestClass: ITestInterface
    {
        public static implicit operator SecondTestClass(string url)
        {
            return new SecondTestClass(url);
        }
        public SecondTestClass(string url)
        {
            Value = GetValueFromTheInternet(url);
        }
        public string Value { get; set; }
    }
