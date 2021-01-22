    public static class DelegateExtensions
    {
        public static Delegate ConvertTo(this Delegate self, Type type)
        {
            if (type == null) { throw new ArgumentNullException("type"); }
            if (self == null) { return null; }
            if (self.GetType() == type)
                return self;
            return Delegate.Combine(
                self.GetInvocationList()
                    .Select(i => Delegate.CreateDelegate(type, i.Target, i.Method))
                    .ToArray());
        }
        public static T ConvertTo<T>(this Delegate self)
        {
            return (T)(object)self.ConvertTo(typeof(T));
        }
    }
