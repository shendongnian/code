    class Derived : Base, IFoo
    {
        public void MethodB()
        {
        }
    }
    abstract class Base
    {
        public Base()
        {
            if (!(this is IFoo))
                throw new InvalidOperationException("must implement IFoo");
        }
        public void MethodA() { }
    }
    interface IFoo
    {
        void MethodA();
        void MethodB();
    }
