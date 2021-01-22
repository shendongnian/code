    static class AccessExtensions
    {
        public static object call(this object o, string methodName, params object[] args)
        {
            var mi = o.GetType ().GetMethod (methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance );
            if (mi != null) {
                return mi.Invoke (o, args);
            }
            return null;
        }
    }
