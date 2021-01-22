    public class HttpNameValueCollection : NameValueCollection
    {
        public override void Add(string name, string value)
        {
            base.Add(name, HttpUtility.UrlEncode(value));
        }
    
        public override string ToString()
        {
            return string.Join("&", Keys.Cast<string>().Select(
                key => string.Format("{0}={1}", key, this[key])));
        }
    }
