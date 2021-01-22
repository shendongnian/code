    //in MessageHeader 
       private void SetValuesDefault()
       {
            MessageHeader header = this;             
            Framework.ObjectPropertyHelper.SetPropertiesToDefault<MessageHeader>(this);
       }
    //in ObjectPropertyHelper
       public static void SetPropertiesToDefault<T>(T obj) 
       {
                Type objectType = typeof(T);
    
                System.Reflection.PropertyInfo [] props = objectType.GetProperties();
    
                foreach (System.Reflection.PropertyInfo property in props)
                {
                    if (property.CanWrite)
                    {
                        string propertyName = property.Name;
                        Type propertyType = property.PropertyType;
    
                        object value = TypeHelper.DefaultForType(propertyType);
                        property.SetValue(obj, value, null);
                    }
                }
        }
    //in TypeHelper
        public static object DefaultForType(Type targetType)
        {
            return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
        }
