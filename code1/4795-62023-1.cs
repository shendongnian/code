        public static class Utilities
        {
            public static Dictionary<int, string> GetEnumPairs(Type type)
            {
               if (type == null)
                throw new ArgumentNullException("type");
    
               if (!type.IsEnum)
                throw new ArgumentException("Only enumeration type is expected.");
    
                Dictionary<int, string> pairs = new Dictionary<int, string>();
    
                foreach (int i in Enum.GetValues(type))
                {
                    pairs.Add(i, Enum.GetName(type, i));
                }
    
                return pairs;
            }
       }
