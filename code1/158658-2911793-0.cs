        object GetObjectProperty(object item,string property)
        {
            if (item == null)
                return null;
            int dotIdx = property.IndexOf('.');
            if (dotIdx > 0)
            {
                object obj = GetObjectProperty(item,property.Substring(0,dotIdx));
                return GetObjectProperty(obj,property.Substring(dotIdx+1));
            }
            PropertyInfo propInfo = null;
            Type objectType = item.GetType();
            while (propInfo == null && objectType != null)
            {
                propInfo = objectType.GetProperty(property, 
                          BindingFlags.Public 
                        | BindingFlags.Instance 
                        | BindingFlags.DeclaredOnly);
                objectType = objectType.BaseType;
            }
            if (propInfo != null)
                return propInfo.GetValue(item, null);
            FieldInfo fieldInfo = item.GetType().GetField(property, 
                          BindingFlags.Public | BindingFlags.Instance);
            if (fieldInfo != null)
                return fieldInfo.GetValue(item);
            return null;
        }
