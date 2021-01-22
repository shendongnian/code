    public interface IMyInterface
    {
        void SomeMethod();
        void SomeOtherMethod();
    }
    public abstract class MyClass : IMyInterface
    {
        // Really implementing this
        public void SomeMethod()
        {
            // ...
        }
        // Derived class must implement this
        public abstract void SomeOtherMethod();
    }
