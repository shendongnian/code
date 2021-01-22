    public static class Names
        {
            public const string name1 = "Name 01";
            public const string name2 = "Name 02";
    
            public static string GetNames(string code)
            {
                foreach (var field in typeof(Names).GetFields())
                {
                    if ((string)field.GetValue(null) == code)
                        return field.Name.ToString();
                }
                return "";
            }
        }
