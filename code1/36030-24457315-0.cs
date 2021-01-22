    abstract class C
    {
        protected abstract void F (D d);
        // Allows calling F cross-hierarchy for any class derived from C
        protected static void F (C c, D d)
        {
            c.F(d);
        }
    }
    class D : C
    {
        protected override void F (D d) { }
        void G (C c)
        {
            // c.F(this);
            F(c, this);
        }
    }
