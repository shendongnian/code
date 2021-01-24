    struct MyCustomStringVariable
    {
        private string value;
        public MyCustomStringVariable(string input)
        {
            value = input;
        }
        public static implicit operator MyCustomStringVariable(string input)
        {
            return new MyCustomStringVariable(input);
        }
        public string GetValue()
        {
            return value;
        }
    }
