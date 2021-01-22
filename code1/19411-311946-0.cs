Here is a more direct solution than using an indexer rather than an Item property:
    public class MyCollection {
        private NameValueCollection _collection;
        [DispId(0)]
        public string this[string name] {
            get { return _collection[name]; }
            set { _collection[name] = value; }
        }
    }
