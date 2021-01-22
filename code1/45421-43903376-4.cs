     public static void ClearProperties(object source, List<Type> InterfaceList = null, Type SearchType = null, BindingFlags ReflectionFlags = BindingFlags.Default)
        {
    
    
            // Set Interfaces[] array size accordingly. (Will be size of our passed InterfaceList, or 1 if InterfaceList is not passed.)
            Type[] Interfaces = new Type[InterfaceList == null ? 1 : InterfaceList.Count];
    
            // If our InterfaceList was not set, get all public properties.
            if (InterfaceList == null)
                Interfaces[0] = source.GetType();
            else // Otherwise, get only the public properties from our passed InterfaceList
                for (int i = 0; i < InterfaceList.Count; i++)
                    Interfaces[i] = source.GetType().GetInterface(InterfaceList[i].Name);
    
            
            IEnumerable<PropertyInfo> propertyList = Enumerable.Empty<PropertyInfo>();
            foreach (Type face in Interfaces)
            {
                if (face != null)
                {
                    // If our SearchType is null, just get all properties that are not already empty
                    if (SearchType == null)
                        propertyList = face.GetProperties(ReflectionFlags).Where(prop => prop != null);
                    else // Otherwise, get all properties that match our SearchType
                        propertyList = face.GetProperties(ReflectionFlags).Where(prop => prop.PropertyType == SearchType);
    
                    // Reset each property
                    foreach (var property in propertyList)
                    {
                        if (property.CanRead && property.CanWrite)
                            property.SetValue(source, null, new object[] { });
                    }
                }
                else
                {
                    // Throw an error or a warning, depends how strict you want to be I guess.
                    Debug.Log("Warning: Passed interface does not belong to object.");
                    //throw new Exception("Warning: Passed interface does not belong to object.");
                }
            }
        }
