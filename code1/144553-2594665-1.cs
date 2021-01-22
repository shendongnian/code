    public class DynamicForwarder : DynamicObject 
    {
        private object _target;
        private Dictionary<string, object> _cache = new Dictionary<string, object>();
        public DynamicForwarder(object target)
        {
            _target = target;
        }
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            // check the cache first
            if (_cache.TryGetValue(binder.Name, out result))
                return true;
            var prop = _target.GetType().GetProperty(binder.Name);
            if (prop == null)
            {
                result = null;
                return false;
            }
            result = prop.GetValue(_target, null);
            _cache.Add(binder.Name, result); // <-------- insert into cache
            return true;
        }
    }
