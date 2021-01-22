    static class DeepCloneExtension
    {
        // consider instance fields, both public and non-public
        private static readonly BindingFlags bindingFlags =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        public static T DeepClone<T>(this T obj) where T : new()
        {
            var type = obj.GetType();
            var result = (T)Activator.CreateInstance(type);
            do
                // copy all fields
                foreach (var field in type.GetFields(bindingFlags))
                    field.SetValue(result, field.GetValue(obj));
            // for every level of hierarchy
            while ((type = type.BaseType) != typeof(object));
            return result;
        }
    }
	
