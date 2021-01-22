    public interface A<in T>
    {
        void SetObject(T obj);
    }
    public interface B { }
    public class BImplementor : B { }
    public class Implementor : A<BImplementor>
    {
        public void SetObject(BImplementor t) { ... }
    }
