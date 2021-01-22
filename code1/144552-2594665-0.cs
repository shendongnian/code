    public class DynamicForwarder : DynamicObject 
    {
        private object _target;
        public DynamicForwarder(object target)
        {
            _target = target;
        }
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            var prop = _target.GetType().GetProperty(binder.Name);
            if (prop == null)
            {
                result = null;
                return false;
            }
            result = prop.GetValue(_target, null);
            return true;
        }
    }
