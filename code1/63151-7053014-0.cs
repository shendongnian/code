        public delegate string ToStringDelegate();
        public static bool OverridesToString(object instance)
        {
            if (instance != null)
            {
                ToStringDelegate func = instance.ToString;
                return (func.Method.DeclaringType == instance.GetType());
            }
            return false;
        }
