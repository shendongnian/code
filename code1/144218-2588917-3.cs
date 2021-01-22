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
    
        public List<CartItem> ShoppingCart
        {
            get { return GetFromSession<List<CartItem>>("ShoppingCart"); }
            set { SetInSession("ShoppingCart", value); }
        }
    }
