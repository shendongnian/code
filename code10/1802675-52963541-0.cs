    public class Mapper<T, U> where U : new()
        {
            public U Convert(T input)
            {
                U newCastType = new U();
                var fromObjectProperties = input.GetType().GetProperties();
                var toObjectProperties = newCastType.GetType().GetProperties();
    
                foreach (var parentProperty in fromObjectProperties)
                {
    
                    foreach (var childProperty in toObjectProperties)
                    {
                        
                        if((parentProperty.Name == childProperty.Name) && parentProperty.PropertyType.IsClass && parentProperty.PropertyType.Name != "String")
                        {
                            
                            var typeInfo = typeof(Mapper<,>);
                            var genericType = typeInfo.MakeGenericType(parentProperty.PropertyType, childProperty.PropertyType);
                            
                            var genericMethodInfo = genericType.GetMethod("Convert");
                            var ojb = Activator.CreateInstance(genericType);
                            var targetValue = genericMethodInfo.Invoke(ojb, new[] { parentProperty.GetValue(input) });
                            childProperty.SetValue(newCastType, targetValue);
                        }
                        else if ((parentProperty.Name == childProperty.Name))
                        {
                            childProperty.SetValue(newCastType, parentProperty.GetValue(input));
                        }
                    }
                }
                /*var fromObjectProperties = input.GetType().GetProperties();
                foreach (var parentProperty in fromObjectProperties)
                {
    
                }*/
                return newCastType;
    
            }
    
        }
