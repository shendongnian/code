     var properties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                List<Address> retVal;
                foreach (var property in properties)
                {
                    var propertyType = property.PropertyType;
                    if (!propertyType.IsGenericType) continue;
    
                    
                    retVal = property.GetValue(item, new object[] { }) as List<Address>;
    
                    if (retVal != null)
                        break;
                }
                
                //now you have your List<Address> in retVal
