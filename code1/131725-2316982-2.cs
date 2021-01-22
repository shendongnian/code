        public static List<KeyValuePair<string, string>> ToPairs(this System.Collections.Specialized.NameValueCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            return collection.Cast<string>().Select(key => new KeyValuePair<string, string>(key, collection[key])).ToList();
        } 
