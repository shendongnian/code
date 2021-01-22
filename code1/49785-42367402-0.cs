            public static string SpacesFromCamel(this string value)
            {
                if (value.Length > 0)
                {
                    var result = new List<char>();
                    char[] array = value.ToCharArray();
                    foreach (var item in array)
                    {
                        if (char.IsUpper(item))
                        {
                            result.Add(' ');
                        }
                        result.Add(item);
                    }
                   
                    return new string(result.ToArray());
                }
                return value;
            }
