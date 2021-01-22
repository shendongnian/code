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
        public int? SomeInteger
        {
            get { return GetFromSession<int?>("SomeInteger"); }
            set { SetInSession("SomeInteger", value); }
        }
    }
