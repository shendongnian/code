            static void Main(string[] args)
            {
                var myObject = new {Id = 123, Name = "Test", IsTest = true};
                var propertyForSerialization = new List<string> { "Id", "Name" };
    
                var result = GetSerializedObject(myObject, propertyForSerialization);
            }
    
            private static string GetSerializedObject(object objForSerialize, List<string> propertyForSerialization)
            {
                var customObject = new ExpandoObject() as IDictionary<string, Object>;
                Type myType = objForSerialize.GetType();
    
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
    
                foreach (PropertyInfo prop in props)
                {
                    foreach (var propForSer in propertyForSerialization)
                    {
                        if (prop.Name == propForSer)
                        {
                            customObject.Add(prop.Name, prop.GetValue(objForSerialize, null));
                        }
                    }
                }
    
               return JsonConvert.SerializeObject(customObject);
            }
