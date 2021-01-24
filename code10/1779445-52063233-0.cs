    public interface IReference<T>
    {
        T Value { get;
    }
    public interface IChangeReference<T>
    {
        void SetValue(T value);
    }
    public class Reference<T>: IReference<T>, IChangeReference<T>
    {
        public Reference(T value) => Value = value;
        public T Value { get; private set; }
        public void SetValue(T value) => Value = value;
    }
    public class SomeConsumer
    {
        private IReference<string> someField;
        ...
    }
