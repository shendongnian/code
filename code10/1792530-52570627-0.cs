      static Configuration CreateConfiguration(Dictionary<string,string> dict)
        {
            try
            {
                return
                    new Configuration
                    {
                        FirstName = dict.getValue("FirstName"),
                        LastName = dict.getValue("LastName"),
                        ID = dict.getValue("ID")                        
                    };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static class Extension
    {
        public static string getValue(this Dictionary<string, String> dict, string keyName)
        {
            string data = null;
            var result = dict.TryGetValue(keyName, out data);
            if (!result)
                throw new KeyNotFoundException($"The given key '{keyName}' was not present in the dictionary. keyname is not found");
            return data;
        }
    }
