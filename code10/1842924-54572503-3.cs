    public class WatchableVariable<T>
    {
        public T Variable { get; set; }
        object IWatchableVariable<T>.Variable
        {
            get => Variable;
            set => Variable = (T)value;
        }
    }
