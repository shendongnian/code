     public static class MyDataBase
        {
            private static List<string> fields = new List<string>();
    
            public static void AddField(string field)
            {
                fields.Add(field);
            }
    
            public static IList<string> FieldsInMyColumn()
            {
                return fields;
            }
        }
