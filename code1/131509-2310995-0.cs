    public abstract class Parameter<T>
    { 
        public bool IsSet { get; protected set; } 
        protected Parameter() { IsSet = false; } 
        public abstract void Set(T value);
        public T Value;
    }
    public class IntParameter : Parameter<int>
    {
        public override void Set(int value)
        {
            Value = value;
            IsSet = true;
        }
    }
