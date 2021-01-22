            PropertyInfo[] properties = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var valProps = from PropertyInfo property in properties
                           where property.GetCustomAttributes(typeof(ValidationAttribute), true).Length > 0
                           select new
                           {
                               Property = property,
                               ValidationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true)
                           };
            foreach (var item in valProps)
            {
                foreach (ValidationAttribute attribute in item.ValidationAttributes)
                {
                    if (attribute.IsValid(item.Property.GetValue(model, null)))
                    {
                        continue;
                    }
                    //Validation fails..
                }
            }
        }
