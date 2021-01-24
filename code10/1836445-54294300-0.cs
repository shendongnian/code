    public async Task ToTable(IFormFile file, string table)
    {
        using (var stream = file.OpenReadStream())
        using (var tx = new StreamReader(stream))
        using (var reader = new CsvReader(tx))
        using (var rd = new CsvDataReader(reader))
        {
            var headers = reader.Context.HeaderRecord;
            var bcp = new SqlBulkCopy(_connection)
            {
                DestinationTableName = table
            };
            //Assume the file headers and table fields have the same names
            foreach(var header in headers)
            {
                bcp.ColumnMappings.Add(header, header);
            }
            await bcp.WriteToServerAsync(rd);                
        }
    }
