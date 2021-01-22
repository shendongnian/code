     public static class DataColumnCollectionExtensions
        {
            public static void RemoveColumns(this DataColumnCollection column, params string[] columns)
            {
                foreach (string c in columns)
                {
                    column.Remove(c);
                }
            }
        }
