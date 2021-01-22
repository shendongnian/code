    public static string[] PropertiesFromType(object atype)
        {
            if (atype == null) return new string[] {};
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            List<string> propNames = new List<string>();
            foreach (PropertyInfo prp in props)
            {
                propNames.Add(prp.Name);
            }
            return propNames.ToArray();
        }
