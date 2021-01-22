            public static void SetProperty(object myObject, string name, string valueString)
            {
                try
                {
                    Type type = myObject.GetType();
                    PropertyInfo property = type.GetProperty(name);
    
                    if (property != null && property.CanWrite)
                    {
                        object value = null;
                        if (property.PropertyType == typeof(double))
                            value = Convert.ToDouble(valueString);
                        else if (property.PropertyType == typeof(int))
                            value = Convert.ToInt32(valueString);
                        else if (property.PropertyType == typeof(bool))
                            value = Convert.ToBoolean(valueString);
                        else if (property.PropertyType == typeof(DateTime))
                            value = DateTime.Parse(valueString);
                        ...
                        else
                            Debug.Assert(false, property.PropertyType.AssemblyQualifiedName + " not handled");
    
                        property.SetValue(myObject, value, null);
                    }
                }
                catch (FormatException)
                {
                    //Unable to set the property '{0}' to '{1}', name, valueString
                }
                catch (NullReferenceException)
                {
                    //Property not defined (or even deprecated)
                }
            }
