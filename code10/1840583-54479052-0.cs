    public DataTable GetExcelDataToTable(string filename, IEnumerable<string> columns)
    {
        ...
        string formattedColumns = string.Join("," columns.Select(column => $"[{column}]"));
        cmd.CommandText = $"SELECT {formattedColumns} FROM [{firstSheet}]";
        ...
    }
                      
