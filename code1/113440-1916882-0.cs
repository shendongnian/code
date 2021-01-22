    class MyDictionary : DictionaryBase {
        private readonly object nullKey = new object();
        void Add(object key, string value) {
           if ( key == null ) { key = nullKey; }
           .. call base methods
        }
    }
