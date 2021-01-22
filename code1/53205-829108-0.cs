    public class Query
    {
        private Dictionary<string,string> _Params = new Dictionary<string,string>();
    
        public overide ToString()
        {
            List<string> returnParams = new List<string>();
    
            foreach (KeyValuePair param in _Params)
            {
                returnParams.Add(String.Format("{0}={1}", param.Key, param.Value));
            }
    
            return String.Format("?{0}", String.Join("&", returnParams.ToArray())); 
        }
    
        public void Add(string key, string value)
        {
            _Params.Add(key, HttpUtility.UrlEncode(value));
        }
    }
    
    Query query = new Query();
    
    query.Add("param1", "value1");
    query.Add("param2", "value2");
    
    return query.ToString();
