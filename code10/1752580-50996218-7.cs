    interface IDataMold
    {
    }
    abstract class DataMold<T> : IDataMold
    {
        public abstract T Result { get; }
    }
