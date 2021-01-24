    public static class NvcExtension
    {
        public static IDictionary<string, object> ToDictionary(this NameValueCollection col)
        {
            IDictionary<string, object> dict = new Dictionary<string, object>();
            foreach (var k in col.AllKeys)
            {
                dict.Add(k, col.GetValues(k).FirstOrDefault());
            }
            return dict;
        }
    }
