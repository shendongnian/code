    public class SomeObject : IReadOnly, ICanReadWrite
    {
        public string Id
        {
            get;
            set;
        }
        public IReadOnly AsReadOnly()
        {
            return this;
        }
    }
