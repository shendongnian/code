Another approach could be to use a wrapper class to adapt NameValueCollection to WCF serialization. Here's a simple example that serializes each name-value pair as a single, comma-delimited string. It then reads that value back into the NameValueCollection upon deserialization:
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
This would allow you to use the type as a standard [DataMember] property on your DataContracts and you would also use standard WCF serialization techniques.
