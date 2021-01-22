    class BaseClass
    {
        public void A()
        {
            Console.WriteLine("BaseClass.A");
        }
    
        public void B()
        {
            Console.WriteLine("BaseClass.B");
        }
    }
    
    class DerivedClass : BaseClass
    {
        new public void A()
        {
            throw new NotSupportedException();
        }
    
        new public void B()
        {
            throw new NotSupportedException();
        }
    
        public void C()
        {
            base.A();
            base.B();
        }
    }
