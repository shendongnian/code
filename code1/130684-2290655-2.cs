       [WebMethod]
        public static nameValue[] GetPageQueryList()
        {
            HttpRequest q = myRequest;
            NameValueCollection n = q.QueryString;
            List<nameValue> thisList = new List<nameValue>();
    
            if (n.HasKeys())
            {
                for (int i = 0; i < n.Count; i++)
                {
                    nameValue newList = new nameValue(n.GetKey(i), n.Get(i));
                    thisList.Add(newList);
                };
            }
            else
            {
                nameValue r = new nameValue("", "");
                thisList.Add(r);
            };
            return thisList.ToArray();
        }
    
    #region nameValue
    public class nameValue
    {
        /// <summary>
        /// web service/webmethod needs 0 parameter constructor
        /// </summary>
        public nameValue()
        {
        }
        public nameValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    
        public string Name;
        public string Value;
    
    }
    #endregion
