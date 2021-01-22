    public static class Extensions
    {
        public static object GetFieldValue(this object instance, string fieldName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = instance.GetType().GetField(fieldName, bindFlags);
            return field == null ? null : field.GetValue(instance);
        }
    }
