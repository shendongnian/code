     public void LogObject(object obj, int indent)
        {
            if (obj == null) return;
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Type tColl = typeof(ICollection<>);
                Type t = property.PropertyType;
                string name = property.Name;
                
               
                object propValue = property.GetValue(obj, null); 
                //check for nested classes as properties
                if (property.PropertyType.Assembly == objType.Assembly)
                {
                    string _result = string.Format("{0}{1}:", indentString, property.Name);
                    log.Info(_result);
                    LogObject(propValue, indent + 2);
                }
                else
                {
                    string _result = string.Format("{0}{1}: {2}", indentString, property.Name, propValue);
                    log.Info(_result);
                }
                
                //check for collection
                if (t.IsGenericType && tColl.IsAssignableFrom(t.GetGenericTypeDefinition()) ||
                    t.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == tColl))
                {
                    //var get = property.GetGetMethod();
                    IEnumerable listObject = (IEnumerable)property.GetValue(obj, null);
                    if (listObject != null)
                    {
                        foreach (object o in listObject)
                        {
                            LogObject(o, indent + 2);
                        }
                    }
                }
            }
        }
