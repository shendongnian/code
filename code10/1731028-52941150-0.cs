    public interface ISessionHelper
        {
            void AddRenewItem(string key, object item);
            object GetItem(string key);
        }
    public class SessionHelper : ISessionHelper
    {
        private readonly Dictionary<string, object> _sessionBag;
        public SessionHelper()
        {
            _sessionBag = new Dictionary<string, object>();
        }
        public void AddRenewItem(string key, object item)
        {
            if (_sessionBag.Keys.Contains(key)) _sessionBag.Remove(key);
            _sessionBag.Add(key, item);
        }
        public object GetItem(string key)
        {
            if (_sessionBag.Keys.Contains(key))
            {
                return _sessionBag[key];
            }
            return null;
        }
    }
