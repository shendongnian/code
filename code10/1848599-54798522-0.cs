    public static class DataReaderExtensions
    {
        public static IEnumerable<KeyValuePair<string, object>[]> Rows(this IDataReader reader)
        {
            while (reader.Read())
            {
                yield return Enumerable.Range(0, reader.FieldCount)
                    .Select(i => new KeyValuePair<string, object>(
                        reader.GetName(i),
                        reader.IsDBNull(i) ? null : reader[i]))
                    .ToArray();
            }
        }
    }
