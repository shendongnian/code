    [Suite]
        public static IEnumerable MySuite
        {
            get
            {
                var suite = new ArrayList{new TestClass1(arg1), TestClass2(arg2)};
                return suite;
            }
        }
    
