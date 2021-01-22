    public class TranslatedDictionary : IDictionary<string, dynamic>
    {
        private IDictionary Original = null;
        public TranslatedDictionary(IDictionary original)
        {
            Original = original;
        }
        public ICollection<string> Keys
        {
            get
            {
                return Original.Keys.Cast<string>().ToList();
            }
        }
        public dynamic this[string key]
        {
            get
            {
                return Original[key] as dynamic;
            }
            set
            {
                Original[key] = value;
            }
        }
        // and so forth, for each method of IDictionary<string, dynamic>
    }
    
    //elsewhere, using your original property and field names:
    Properties = new TranslatedDictionary(properties);
    
    
