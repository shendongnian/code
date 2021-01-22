    interface IA
    {
        void MethodA();
    }
    
    interface IB : IA
    {
        void MethodB();
    }
    
    class B : IB
    {
        public void MethodA() { }
        public void MethodB() { }
    }
    
    class AB : IA, IB
    {
        public void MethodA() { }
        public void MethodB() { }
    }
