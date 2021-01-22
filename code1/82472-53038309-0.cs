        public dynamic Test1Binding { get; set; }
        public TestDTO Test1
        {
            get { return (TestDTO)Test1Binding; }
            set { SetBinding(nameof(Test1Binding), value); }
        }
