     public static Type GetRes<Type>(Dictionary<string, object> dict, string key)
            {
                if (dict.ContainsKey(key) && dict[key] is Type)
                {
                    return (Type)dict[key];
                }
                return default(Type);
            }
