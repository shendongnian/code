    public class Thing
    {
        // typical per-instance stuff
        int _member1;
        protected virtual void Foo() { ... }
        public void Bar() { ... }
        // factory method
        public static Thing Make()
        {
            return new Thing();
        }
    }
