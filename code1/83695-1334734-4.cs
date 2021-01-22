    public class Derived : Base
    {
        public Derived(Base b) : base(b) { }
        // additional members...
    }
    public class Base
    {
        // members not shown...
        public Base() {}
        protected Base(Base b) {
           this.Member1 = b.Member1;
            // etc
        }
        // additional members...
    }
