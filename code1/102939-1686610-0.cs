    private class Source
    {
        public SomeType<String> value1
        {
            get;
            set;
        }
    }
    source.value1 = new SomeType<string>() { Value = "Test" };
