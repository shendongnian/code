    public abstract class Base
    {
        public int Property { get { return PropertyImpl; } }
        protected abstract int PropertyImpl {get;}
    }
    public class Derived : Base
    {
        public new int Property {get;set;}
        protected override int PropertyImpl
        {
            get { return Property; }
        }
    }
