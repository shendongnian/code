     public static class AttributeExtensions
    {
        public static TValue[] GetAttributeValue<TAttribute, TValue>(
            this Type type,
            Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            var rs = new List<TValue>();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var att = prop.GetCustomAttributes(
               typeof(TAttribute), true).FirstOrDefault() as TAttribute;
                if (att != null)
                {
                    rs.Add(valueSelector(att));
                }                
            }           
            return rs.ToArray();
        }
    }
