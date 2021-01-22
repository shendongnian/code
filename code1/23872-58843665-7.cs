    /// Gets the column ordinal, given the name of the column.
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="name">The name of the column.</param>
    /// <returns> The zero-based column ordinal. -1 if the column does not exist.</returns>
    public static int GetOrdinalSoft2(this SqlDataReader reader, string name)
    {
        try
        {
            // Note that "Statistics" will not be accounted for in this implemenation
            // If you have SqlConnection.StatisticsEnabled set to true (the default is false), you probably don't want to use this method
            // All of the following logic is inspired by the actual implementation of the framework:
            // https://referencesource.microsoft.com/#System.Data/fx/src/data/System/Data/SqlClient/SqlDataReader.cs,d66096b6f57cac74
            if (name == null)
                throw new ArgumentNullException("fieldName");
            Type sqlDataReaderType = typeof(SqlDataReader);
            object fieldNameLookup = sqlDataReaderType.GetField("_fieldNameLookup", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(reader);
            Type fieldNameLookupType = fieldNameLookup.GetType();
            if (fieldNameLookup == null)
            {
                MethodInfo checkMetaDataIsReady = sqlDataReaderType.GetRuntimeMethods().First(x => x.Name == "CheckMetaDataIsReady" && x.GetParameters().Length == 0);
                checkMetaDataIsReady.Invoke(reader, null);
                ConstructorInfo ctor = fieldNameLookupType.GetConstructor(new[] { typeof(SqlDataReader), typeof(int) });
                fieldNameLookup = ctor.Invoke(new object[] { reader, sqlDataReaderType.GetField("_defaultLCID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(reader) });
            }
            MethodInfo indexOf = fieldNameLookupType.GetMethod("IndexOf", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(string) }, null);
            return (int)indexOf.Invoke(fieldNameLookup, new object[] { name });
        }
        catch
        {
            // .NET Implemenation might have changed, revert back to the classic solution.
            if (reader.FieldCount > 11) // Performance observation by b_levitt
            {
                try
                {
                    return reader.GetOrdinal(name);
                }
                catch
                {
                    return -1;
                }
            }
            else
            {
                var exists = Enumerable.Range(0, reader.FieldCount).Any(i => string.Equals(rdr.GetName(i), reader, StringComparison.OrdinalIgnoreCase));
                if (exists)
                    return reader.GetOrdinal(name);
                else
                    return -1;
            }
        }
    }
