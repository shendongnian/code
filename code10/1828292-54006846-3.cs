    public static class DataReaderExtension
        {
            public static T Get<T>(this IDataReader reader, string column) where T : IComparable
            {
                try
                {
                    int index = reader.GetOrdinal(column);
                    
                    if (!reader.IsDBNull(index))
                    {
                        return (T)reader[index];
                    }
                }
                catch (IndexOutOfRangeException) { throw new Exception($"Column, '{column}' not found."); }
    
                return default(T);
            }
    
            public static IEnumerable<string> GetColumns(this IDataReader reader)
            {
                IEnumerable<string> columns = new List<string>();
                if (reader != null && reader.FieldCount > 0)
                {
                    columns = Enumerable.Range(0, reader.FieldCount)
                                        .Select(index => reader.GetName(index))
                                        .ToList();
                }
    
                return columns;
            }
        }
