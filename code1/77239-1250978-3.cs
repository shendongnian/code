    class CustomPrincipal : IPrincipal, IIdentity
    {
        private string cn;
        public CustomPrincipal(string cn)
        {
            if (string.IsNullOrEmpty(cn)) throw new ArgumentNullException("cn");
            this.cn = cn;
        }
        // perhaps not ideal, but serves as an example
        readonly Dictionary<string, bool> roleCache =
            new Dictionary<string, bool>();
        public override string ToString() { return cn; }
        bool IIdentity.IsAuthenticated { get { return true; } }
        string IIdentity.AuthenticationType { get { return "iris scan"; } }
        string IIdentity.Name { get { return cn; } }
        IIdentity IPrincipal.Identity { get { return this; } }
        
        bool IPrincipal.IsInRole(string role)
        {
            if (string.IsNullOrEmpty(role)) return true; // assume anon OK
            lock (roleCache)
            {
                bool value;
                if (!roleCache.TryGetValue(role, out value)) {
                    value = RoleHasAccess(cn, role);
                    roleCache.Add(role, value);
                }
                return value;
            }
        }
        private static bool RoleHasAccess(string cn, string role)
        {
            //TODO: talk to your own security store
        }
    }
 
