        static bool IsRequiredProperty(Type t, string name) {
            PropertyInfo pi = t.GetProperty(name);
            if (pi == null) throw new ArgumentException();
            // First check if present on property as-is
            if (pi.GetCustomAttributes(typeof(RequiredAttribute), false).Length > 0) return true;
            // Then check if it is "inherited" from another type
            var prov = t.GetCustomAttributes(typeof(AttributeProviderAttribute), false);
            if (prov.Length > 0) {
                t = (prov[0] as AttributeProviderAttribute).Type;
                return IsRequiredProperty(t, name);
            }
            return false;
        }
