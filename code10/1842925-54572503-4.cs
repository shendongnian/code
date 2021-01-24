    public interface IWatchableVariable<out T>
    {
        T Variable { get; }
        void SetVariable(object value);
    }
    public class WatchableVariable<T> : IWatchableVariable<T>
    {
        public T Variable { get; set; }
        public void SetVariable(object value)
        {
            Variable = (T)value;
        }
    }
