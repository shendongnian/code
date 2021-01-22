    public static int GetOrdinalSoft(this SqlDataReader reader, string name)
    {
        // Note that "Statistics" will not be accounted for in this implemenation
        // If you have SqlConnection.StatisticsEnabled set to true (the default is false), you probably don't want to use this method
        // In order to avoid running into issues in future versions of .NET where the implemenation might change, consider wrapping this method in a try/catch
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
            checkMetaDataIsReady.Invoke(fieldNameLookup, null);
            ConstructorInfo ctor = fieldNameLookupType.GetConstructor(new[] { typeof(SqlDataReader), typeof(int) });
            fieldNameLookup = ctor.Invoke(new object[] { reader, sqlDataReaderType.GetField("_defaultLCID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(reader) });
        }
        MethodInfo indexOf = fieldNameLookupType.GetMethod("IndexOf", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(string) }, null);
        return (int)indexOf.Invoke(fieldNameLookup, new object[] { name });
    }
