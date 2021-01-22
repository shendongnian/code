    public interface IHasFoo
    {
        void foo();
    }
    public class B : IHasFoo // you don't need to explicitly subclass object
    {
        public void foo()
        {
        }
    }
    public class A : IHasFoo // you don't need to explicitly subclass object
    {
        public void foo()
        {
        }
    }
    void bar<T>(T t) where T : IHasFoo
    {
        t.foo(); // works
    }
