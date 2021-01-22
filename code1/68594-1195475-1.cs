            private static object CreatePropertyValue(string name, object value)
            {
                Type propertyValue = Type.GetTypeFromProgID("com.sun.star.beans.PropertyValue", true);
                object oPropertyValue = System.Activator.CreateInstance(propertyValue);
                FieldInfo nameInfo =    propertyValue.GetField("Name");
                nameInfo.SetValue(oPropertyValue,name);
                FieldInfo valueInfo = propertyValue.GetField("Value");
                valueInfo.SetValue(oPropertyValue, value);
                return oPropertyValue;
            }
    
            #endregion
            private static object Invoke(object obj, string method, BindingFlags binding, params object[] par)
            {
                return obj.GetType().InvokeMember(method, binding, null, obj, par);
            } 
    
        /// Convert into OO file format  
        /// The file.   
        /// The converted file  
    
        private static string PathConverter( string file)  
        { 
           try  
          { 
             file = file.Replace(@"\", "/"); 
             return "file:///"+file;  
          } 
           catch (System.Exception ex)  
          { 
    
              throw ex;  
          } 
    
       }
 
