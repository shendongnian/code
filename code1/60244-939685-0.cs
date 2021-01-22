    [CollectionDataContract]
    public class NameValueCollectionWrapper : IEnumerable 
    {
        public NameValueCollectionWrapper() : this(new NameValueCollection()) { }
        public NameValueCollectionWrapper(NameValueCollection nvc) 
        {
            InnerCollection = nvc;
        }
        public NameValueCollection InnerCollection { get; private set; }
        public void Add(object value) 
        {
            var nvString = value as string;
            if (nvString != null) 
            {
                var nv = nvString.Split(',');
                InnerCollection.Add(nv[0], nv[1]);
            }
        }
        public IEnumerator GetEnumerator() 
        {
            foreach (string key in InnerCollection) 
            {
                yield return string.Format("{0},{1}", key, InnerCollection[key]);
            }
        }
    }
