        private object GetPropertyValue(object item, string property)
        {
            // No value
            object value = null;
            var pi = item.GetType().GetProperty(property);
                
            // If we have a valid property, get the value
            if (pi != null)
                value = pi.GetValue(item, null);
            // Done
            return value;
        }
