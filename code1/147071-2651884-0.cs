    public class foo<T> where T : ibar, new()
    ...
    public interface ibar
    {
        void someMethod();
    }
    public abstract class bar : ibar
    {
        public abstract void someMethod();
        // Some implementation
    }
