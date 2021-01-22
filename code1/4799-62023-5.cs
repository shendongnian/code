    public static class Enumeration
    {
        public static IDictionary<int, string> GetAll<TEnum>() where TEnum: struct
        {
            var enumerationType = typeof (TEnum);
    
            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");
    
            var dictionary = new Dictionary<int, string>();
    
            foreach (int value in Enum.GetValues(enumerationType))
            {
                var name = Enum.GetName(enumerationType, value);
                dictionary.Add(value, name);
            }
    
            return dictionary;
        }
    }
