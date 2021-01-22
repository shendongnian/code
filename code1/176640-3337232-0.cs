    interface InterfaceA
    {
        void MethodA();
    }
    class ClassA : InterfaceA
    {
        void InterfaceA.MethodA()
        { MethodB(); }
        protected virtual void MethodB()
        { 
        }
    }
