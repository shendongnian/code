    public interface IRemove<out T>
    {
        T Remove();
        bool IsCompleted { get; }
    }
    public abstract class RemoveInfinite<T> : IRemove<T>
    {
        public bool IsCompleted
        {
            get { return false; }
        }
        public abstract T Remove();
    }
