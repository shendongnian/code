    public class SomeObject : IReadOnly, ICanReadWrite
    {
        public string Id
        {
            get;
            set;
        }
        public IReadOnly AsReadOnly()
        {
            return new ReadOnly(this);
        }
    }
    public class ReadOnly : IReadOnly
    {
        private IReadOnly _WrappedObject;
        public ReadOnly(IReadOnly wrappedObject)
        {
            _WrappedObject = wrappedObject;
        }
        public string Id
        {
            get { return _WrappedObject.Id; }
        }
    }
