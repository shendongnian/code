    public class Metadata<TData> : IMetadata<TData>
    {
        public Metadata(TData data)
        {
            this.Data = data;
        }
        public Type DataType
        {
            get { return typeof(TData); }
        }
        object IMetadata.Data
        {
            get { return this.Data; }
        }
        public TData Data { get; private set; }
    }
