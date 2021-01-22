        static public PropertyInfo GetPropertyOrInterfaceProperty(this Type type, string propertyName, BindingFlags bindingAttr = BindingFlags.Public|BindingFlags.Instance)
        {
            if (!type.IsInterface) {
                return type.GetProperty(propertyName, bindingAttr);
            }
            return type.GetInterfaces().Select(i => i.GetProperty( propertyName, bindingAttr)).Distinct().Single();
        }
