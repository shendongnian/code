    public class ClassA
    {
        private readonly Lazy<IClassB> _classB;
        public Thing1(Lazy<IClassB> classB)
        {
            _classB = classB;
        }
        public IClassB ClassB => _classB.Value;
    }
    public class ClassB 
    {
        public IClassA _classA { get; set; }
        public ClassB (IClassA classA)
        {
            _classA = classA;
        }
    }
