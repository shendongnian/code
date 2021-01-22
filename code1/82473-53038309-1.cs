        [DependsOn("Test1Binding.TestString")]
        public string Test2
        {
            get { return Test1Binding.TestString; }
        }
