    public class HttpContextSessionWrapper : ISessionWrapper
    {
        private T GetFromSession<T>(string key)
        {
            return (T) HttpContext.Current.Session[key];
        }
    
        private void SetInSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
    
        public string Username
        {
            get { return GetFromSession<string>("username"); }
            set { SetInSession("username", value); }
        }
    }
