    public class _parentBLL
    {
        public ClassA class_A
        {
            get { return new ClassA(); }
        }
        private readonly ClassB _class_B = new ClassB();
        public ClassB class_B
        {
            get { return _class_B; }
        }
    }
