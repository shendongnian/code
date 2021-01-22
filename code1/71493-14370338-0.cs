    class B: IInterface
    {    
        protected void MethodToExpose()
        {
            A a = new A();
            a.MethodToExpose();
        }
        protected void NewMethodInB()
        {
        }
    }
