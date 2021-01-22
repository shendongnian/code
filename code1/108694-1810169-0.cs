    static class ObjectExtensions {
        public static T GetPropValue<T>(this object value, string propertyName) {
            if (value == null) { throw new ArgumentNullException("value"); }
            if (String.IsNullOrEmpty(propertyName)) { throw new ArgumentException("propertyName"); }
            PropertyInfo info = value.GetType().GetProperty(propertyName);
            return (T)info.GetValue(value, null);
        }
    }
