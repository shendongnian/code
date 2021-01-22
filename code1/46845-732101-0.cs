        public HashSet<string> GetIntrinsicPropertyKeys()
        {
            Type t = this.GetType();
            PropertyInfo[] properties = t.GetProperties();
            HashSet<string> keys = new HashSet<string>();
            foreach (PropertyInfo pNfo in properties)
            {
                keys.Add(pNfo.Name);
            }
            return keys;
        }
        public string GetIntrinsicProperty(string propertyKey)
        {
            HashSet<string> allowableKeys = this.GetIntrinsicPropertyKeys();
            String returnValue = null;
            if (allowableKeys.Contains(propertyKey))
            {
                Type t = this.GetType();
                PropertyInfo prop = t.GetProperty(propertyKey);
                returnValue = (string)prop.GetValue(this, null);
            }
            return returnValue;
        }
