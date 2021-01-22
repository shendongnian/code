    public abstract class Base
    {
        public abstract int Property { get; }
    }
    public abstract class SecondBase : Base
    {
        public sealed override int Property
        {
            get { return PropertyImpl; }
        }
        protected abstract int PropertyImpl { get; }
    }
    public class Derived : SecondBase
    {
        public new int Property { get; set; }
        protected override int PropertyImpl
        {
            get { return Property; }
        }
    }
