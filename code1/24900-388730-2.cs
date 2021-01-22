    public static Result<T> Generic<T>(T arg) {
        return Cache<T>.CachedDelegate(arg);
    }
    internal static class Cache<T>
    {
        public static readonly Func<T, Result<T>> CachedDelegate;
        static Cache()
        {
            MethodInfo method;
            if (typeof(T).IsValueType)
                method = typeof(Program).GetMethod("ImplVal")
                    .MakeGenericMethod(typeof(T));
            else
                method = typeof(Program).GetMethod("ImplRef")
                    .MakeGenericMethod(typeof(T));
            CachedDelegate = (Func<T, Result<T>>)Delegate.CreateDelegate(
                typeof(Func<T, Result<T>>), method);
        }
    }
