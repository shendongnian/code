    public interface IMyObject {
        Type DataType { get; }
    }
    
    public class MyObject<T> : IMyObject<T>, IMyObject {
        public Type DataType {
            get { return typeof(T); }
        }
    }
