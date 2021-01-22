    // using System.Data;
    // using System.Data.OleDb;
    // using System.Globalization;
    // using System.IO;
    static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
    {
        string header = isFirstRowHeader ? "Yes" : "No";
        string pathOnly = Path.GetDirectoryName(path);
        string fileName = Path.GetFileName(path);
        string sql = @"SELECT * FROM [" + fileName + "]";
        using(OleDbConnection connection = new OleDbConnection(
                  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly + 
                  ";Extended Properties=\"Text;HDR=" + header + "\""))
        using(OleDbCommand command = new OleDbCommand(sql, connection))
        using(OleDbDataAdapter adapter = new OleDbDataAdapter(command))
        {
            DataTable dataTable = new DataTable();
            dataTable.Locale = CultureInfo.CurrentCulture;
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
