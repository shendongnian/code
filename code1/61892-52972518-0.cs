    public static class CloneUtil<T>
    {
        private static Func<object, object> clone;
        static CloneUtil()
        {
            var cloneMethod = typeof(T).GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            clone = (Func<object, object>)cloneMethod.CreateDelegate(typeof(Func<object, object>));
        }
        public static T Clone(T obj) => (T)clone(obj);
    }
    public static class CloneUtil
    {
        public static T Clone<T>(this T obj) => CloneUtil<T>.Clone(obj);
    }
