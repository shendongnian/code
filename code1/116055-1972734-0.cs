    public class ClassB
    {
        private readonly ClassA _a;
        public b(ClassA a)
        {
            _a = a;
        }
        public void GetB()
        {
            _a.GetA();
            // Other logic
        }
    }
