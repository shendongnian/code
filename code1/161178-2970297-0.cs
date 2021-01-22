    public class ProxyBase
    {
        public override bool Equals(object obj)
        {
            var proxy = this as IProxyTargetAccessor;
            if (proxy == null)
            {
                return base.Equals(obj);
            }
            var target = proxy.DynProxyGetTarget();
            if (target == null)
            {
                return base.Equals(obj);
            }
            return target.Equals(obj);
        }
        // same for GetHashCode
    }
