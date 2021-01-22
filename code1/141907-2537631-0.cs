    class ImmutableType
    {
        private string _test;
        public string Test
        {
            get { return _test; }
        }
        public ImmutableType(string test)
        {
            _test = test;
        }
    }
