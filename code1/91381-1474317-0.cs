    public interface IFoo
    {
        void Bar();
    }
    public abstract class FooBase : IFoo
    {
        public abstract void Bar()
        {
            // Do some stuff usually required for IFoo.
        }
    }
