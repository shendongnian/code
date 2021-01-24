        public static D GetMethodInClass<D>(string methodName, object target) where D : class
        {
            var mi = target.GetType().GetMethod(methodName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return (D)(object)Delegate.CreateDelegate(typeof(D), target, mi);
        }
