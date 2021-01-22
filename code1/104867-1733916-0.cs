        void Form_SetControlProperty(
            String controlName, String propertyName, object value)
        {
            FieldInfo controlField = this.GetType().GetField(controlName, 
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            object control = controlField.GetValue(this);
            PropertyInfo property = control.GetType().GetProperty(propertyName);
            property.SetValue(control, value, new object[0]);
        }
