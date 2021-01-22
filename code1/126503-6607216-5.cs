        public static Dictionary<string, object> ToDictionary(this Enum enumeration)
        {
            Array names = Enum.GetNames(enumeration.GetType());
           Dictionary<string, object> dictionary = new Dictionary<string, object>();
           foreach (string name in names)
           {
               dictionary.Add(name, typeof(Domain.CustomerType).GetField(name).GetRawConstantValue() );
           }
           return dictionary;
        }
        public static List<KeyValuePair<string, object>> ToList(this Enum enumObject)
        {
            return enumObject.ToDictionary().ToList();
        }
      
    }
