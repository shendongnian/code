    public class SessionLifetimeManager : LifetimeManager
    {
        private string _key = Guid.NewGuid().ToString();
        public override void RemoveValue(ILifetimeContainer container = null)
        {
            HttpContext.Current.Session.Remove(_key);
        }
        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            HttpContext.Current.Session[_key] = newValue;
        }
        public override object GetValue(ILifetimeContainer container = null)
        {
            return HttpContext.Current.Session[_key];
        }
        protected override LifetimeManager OnCreateLifetimeManager()
        {
            return new PerSessionLifetimeManager();
        }
    }
