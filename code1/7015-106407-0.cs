    class BaseClass
    {
        public void A()
        {
        }
    
        public void B()
        {
        }
    }
    
    class DerivedClass : BaseClass
    {
        private new void A()
        {
            base.A();
        }
    
        private new void B()
        {
            base.B();
        }
    
        public void C()
        {
            A();
            B();
        }
    }
