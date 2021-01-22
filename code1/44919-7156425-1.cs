        var fileVersion = GetCustomAttributeValue<AssemblyFileVersionAttribute>(assembly, "Version");
        private static string GetCustomAttributeValue<T>(Assembly assembly, string propertyName)
            where T : Attribute
        {
            if (assembly == null || string.IsNullOrEmpty(propertyName)) return string.Empty;
            object[] attributes = assembly.GetCustomAttributes(typeof(T), false);            
            if (attributes.Length == 0) return string.Empty;
            var attribute = attributes[0] as T;
            if (attribute == null) return string.Empty;
            var propertyInfo = attribute.GetType().GetProperty(propertyName);
            if (propertyInfo == null) return string.Empty;
            var value = propertyInfo.GetValue(attribute, null);
            return value.ToString();
        }
