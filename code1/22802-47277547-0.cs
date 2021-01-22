        static public IEnumerable<PropertyInfo> GetPropertiesAndInterfaceProperties(this Type type, BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance)
        {
            if (!type.IsInterface) {
                return type.GetProperties( bindingAttr);
            }
            return type.GetInterfaces().SelectMany(i => i.GetProperties(bindingAttr)).Distinct();
        }
