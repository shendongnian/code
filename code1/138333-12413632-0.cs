    public class B
    {
        private Independent<string> _someProperty = new Independent<string>();
        public string SomeProperty
        {
            get { return _someProperty; }
            set { _someProperty.Value = value; }
        }
    }
    public class A
    {
        private Dependent<string> _dependentProperty;
        public A()
        {
            _dependentProperty = new Dependent<string>(() =>
                FirstB.SomeProperty + ", " + SecondB.SomeProperty + ", " + ThirdB.SomeProperty);
        }
        public string DependentProperty
        {
            get { return _dependentProperty; }
        }
        private Independent<int> _id = new Independent<int>();
        public int Id
        {
            get { return _id; }
            set { _id.Value = value; }
        }
        private Independent<string> _name = new Independent<string>();
        public string Name
        {
            get { return _name; }
            set { _name.Value = value; }
        }
        private Independent<B> _firstB = new Independent<B>();
        public B FirstB
        {
            get { return _firstB; }
            set { _firstB.Value = value; }
        }
        private Independent<B> _secondB = new Independent<B>();
        public B SecondB
        {
            get { return _secondB; }
            set { _secondB.Value = value; }
        }
        private Independent<B> _thirdB = new Independent<B>();
        public B ThirdB
        {
            get { return _thirdB; }
            set { _thirdB.Value = value; }
        }
    }
