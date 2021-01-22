    public static IEnumerable<string> GetExcelSheetNames(string excelFile)
    {
        var connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
              "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
        using (var connection = new OleDbConnection(connectionString))
        {
            connection.Open();
            using (var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null))
            {
                return (dt ?? new DataTable())
                    .Rows
                    .Cast<DataRow>()
                    .Select(row => row["TABLE_NAME"].ToString());
            }
        }
    }
