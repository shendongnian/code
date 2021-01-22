    public abstract class SelfRef<T> where T : SelfRef<T>, new()
    {
        public SelfRef<T> Parent { get; set; }
        public T AddNew()
        {
           return new T { Parent = this };
        }
    }
