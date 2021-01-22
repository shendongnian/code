        static string getPropertyValueFromProperty(object control, string propertyName)
        {
            var controlType = control.GetType();
            var property = controlType.GetProperty(propertyName, BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (property == null)
                throw new InvalidOperationException(string.Format("Property “{0}” does not exist in type “{1}”.", propertyName, controlType.FullName));
            if (property.PropertyType != typeof(string))
                throw new InvalidOperationException(string.Format("Property “{0}” in type “{1}” does not have the type “string”.", propertyName, controlType.FullName));
            return (string) property.GetValue(control, null);
        }
