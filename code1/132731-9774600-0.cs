    interface IPartial
    {
        void A();
        void B();
    }
    class Partial : IPartial
    {
        public void A()
        {
            // Implementation here
        }
        void IPartial.B()
        {
            throw new NotImplementedException();
        }
    }
    class Main
    {
        Main()
        {
            Partial t = new Partial();
            t.A();
            t.B(); // Compiler error
            IPartial s = new Partial();
            s.A();
            s.B(); // Runtime error
        }
    }
