    public class Link<TValue>
    {
        private readonly TValue value;
        private readonly Link<TValue> next;
        public Link(TValue value, Link<TValue> next)
        {
            this.value = value;
            this.next = next;
        } 
        public TValue Value 
        { 
            get { return value; }
        }
        public Link<TValue> Next 
        {
            get { return next; }
        }
    
        public IEnumerable<TValue> ToEnumerable()
        {
            for (Link<TValue> v = this; v != null; v = v.next)
                yield return v.value;
        }
    }
