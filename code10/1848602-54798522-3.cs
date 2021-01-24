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
                    var query = rdr.Rows()
                        .Select(r => new { Inputs = r });
                    var settings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    };
                    return JsonConvert.SerializeObject(query, Formatting.Indented, settings);
                }
            }
        }
    }
