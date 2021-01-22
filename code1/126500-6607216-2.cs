           Array Evalues =  Enum.GetValues(enumeration.GetType());
           Dictionary<string, object> dictionary = new Dictionary<string, object>();
           foreach (object value in Evalues)
           {
               dictionary.Add(Enum.GetName(enumeration.GetType(), value), value);
           }
           return dictionary;
        }   
