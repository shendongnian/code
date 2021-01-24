    foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(bool))
                {
                    bool value = (bool)propertyInfo.GetValue(data, null);
                    if (value)
                    {
                        var attribute = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute), true)
                                            .Cast<DisplayAttribute>().Single();
                        string displayName = attribute.Name;
                        list.Add(displayName);
                    }
                }
            }
