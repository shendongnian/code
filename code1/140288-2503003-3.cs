    public interface ISuck
    {
        Stream Munge(ArrayList list);
        Stream Munge(Hashtable ht);
        string Munge(NameValueCollection nvc);
        object Munge(IEnumerable enumerable);
    }
    public class HateHateHate : ISuck
    {
        public FileStream Munge(ICollection collection);
        public NetworkStream Munge(IEnumerable enumerable);
        public MemoryStream Munge(Hashtable ht);
        public Stream Munge(ICloneable cloneable);
        public object Munge(object o);
        public Stream Munge(IDictionary dic);
    }
