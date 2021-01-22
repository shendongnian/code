Here is a better solution that uses an indexer rather than an <a href="#301260">Item method</a>:
    public class MyCollection {
        private NameValueCollection _collection;
        [DispId(0)]
        public string this[string name] {
            get { return _collection[name]; }
            set { _collection[name] = value; }
        }
    }
