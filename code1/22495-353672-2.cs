    class TypeHandler
    {
        public static List<string> GetCommonProperties(Type[] types)
        {
            Dictionary<string, int> propertyCounts = new Dictionary<string, int>();
    
            foreach (Type type in types)
            {
                foreach (PropertyInfo info in type.GetProperties())
                {
                    string name = info.Name;
                    if (!propertyCounts.ContainsKey(name)) propertyCounts.Add(name, 0);
                    propertyCounts[name]++;
                }
            }
    
            List<string> propertyNames = new List<string>();
    
            foreach (string name in propertyCounts.Keys)
            {
                if (propertyCounts[name] == types.Length) propertyNames.Add(name);
            }
    
            return propertyNames;
        }
    }
