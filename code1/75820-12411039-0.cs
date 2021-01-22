    public static class ObjectExt
    {
        public static object CopyFrom(this object obj, object otherObject)
        {
            PropertyInfo[] srcFields = otherObject.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
            PropertyInfo[] destFields = obj.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
            foreach (var property in srcFields) {
                var dest = destFields.FirstOrDefault(x => x.Name == property.Name);
                if (dest != null)
                    dest.SetValue(obj, property.GetValue(otherObject, null), null);
            }
            return obj;
        }
    }
