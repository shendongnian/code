    public static class Common
    {
        private static StringDictionary _domains;
        static Common()
        {
            _domains = new StringDictionary();
            _domains.Add("212", "Location A");
            _domains.Add("555", "Location B");
            _domains.Add("747", "Location C");
            _domains.Add("000", "Location D");
        }
        public static StringDictionary Domains
        {
            get
            {
                return _domains;
            }
        }
    }
