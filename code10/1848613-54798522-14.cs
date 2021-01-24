    public static string ExtractRows(string connectionString, string sheetName)
    {
        using (var conn = new OleDbConnection(connectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT * FROM [{0}]", sheetName);
                using (var rdr = cmd.ExecuteReader())
                {
                    var query = rdr
                        // Wrap the IDataReader in a LINQ enumerator returning an array of key/value pairs for each row.
                        // Project the first two columns into a single anonymous object.
                        .SelectRows(r =>
                        {
                            // Check we have two columns in the row, and the first (Name) column value is non-null.
                            // You might instead check that we have at least two columns.
                            if (r.FieldCount != 2 || r.IsDBNull(0))
                                throw new InvalidDataException();
                            return new { Name = r[0].ToString(), Value = r[1] };
                        })
                        // Break the columns into chunks when the first name repeats
                        .ChunkWhile((l, r) => l[0].Name != r.Name)
                        // Wrap in the container Inputs object
                        .Select(r => new { Inputs = r });
                    // Serialize in camel case
                    var settings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    };
                    return JsonConvert.SerializeObject(query, Formatting.Indented, settings);
                }
            }
        }
    }
