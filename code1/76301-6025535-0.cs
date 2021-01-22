        [CrmAttribute("firstname")]
        public string FirstName
        {
           get { return GetPropValue<string>(MethodBase.GetCurrentMethod().Name); }
           set { SetPropValue(MethodBase.GetCurrentMethod().Name, value); }
        }
        
        // this is in a base class, skipped that bit for clairty
        public T GetPropValue<T>(string propName)
        {
            propName = propName.Replace("get_", "").Replace("set_", "");
            string attributeName = GetCrmAttributeName(propName);
            return GetAttributeValue<T>(attributeName);            
        }
        
        public void SetPropValue(string propName, object value)
        {
            propName = propName.Replace("get_", "").Replace("set_", "");
            string attributeName = GetCrmAttributeName(propName);
            SetAttributeValue(attributeName, value);
        }
        
        private static Dictionary<string, string> PropToAttributeMap = new Dictionary<string, string>();
        private string GetCrmAttributeName(string propertyName)
        {
             // keyName for our propertyName to (static) CrmAttributeName cache
             string keyName = this.GetType().Name + propertyName;
             // have we already done this mapping?
             if (!PropToAttributeMap.ContainsKey(keyName))
             {
                 Type t = this.GetType();
                 PropertyInfo info = t.GetProperty(propertyName);
                 if (info == null)
                 {
                     throw new Exception("Cannot find a propety called " + propertyName);
                 }
        
                 object[] attrs = info.GetCustomAttributes(false);
                 foreach (object o in attrs)
                 {
                     CrmAttributeAttribute attr = o as CrmAttributeAttribute ;
                     if (attr != null)
                     {
                         // found it. Save the mapping for next time.
                         PropToAttributeMap[keyName] = attr.AttributeName;
                         return attr.AttributeName;
                     }
                  }
                  throw new Exception("Missing MemberOf attribute for " + info.Name + "." + propertyName + ". Could not auto-access value");
               }
        
               // return the existing mapping
               string result = PropToAttributeMap[keyName];
               return result;
            }
