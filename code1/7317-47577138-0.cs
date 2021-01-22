        public static DataTable GetDataFromCsvFile(string filePath, bool isFirstRowHeader = true)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The path: " + filePath + " doesn't exist!");
            }
            if (!(Path.GetExtension(filePath) ?? string.Empty).ToUpper().Equals(".CSV"))
            {
                throw new ArgumentException("Only CSV files are supported");
            }
            var pathOnly = Path.GetDirectoryName(filePath);
            var filename = Path.GetFileName(filePath);
            var schemaIni =
                $"[{filename}]{Environment.NewLine}" +
                $"Format=CSVDelimited{Environment.NewLine}" +
                $"ColNameHeader={(isFirstRowHeader ? "True" : "False")}{Environment.NewLine}" +
                $"MaxScanRows=0{Environment.NewLine}" +
                $" ; scan all rows for data type{Environment.NewLine}" +
                $" ; This file was automatically generated";
            var schemaFile = pathOnly != null ? Path.Combine(pathOnly, "schema.ini") : "schema.ini";
            File.WriteAllText(schemaFile, schemaIni);
            try
            {
                var sqlCommand = $@"SELECT * FROM [{filename}]";
                var oleDbConnString =
                    $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={pathOnly};Extended Properties=\"Text;HDR={(isFirstRowHeader ? "Yes" : "No")}\"";
                using (var oleDbConnection = new OleDbConnection(oleDbConnString))
                using (var adapter = new OleDbDataAdapter(sqlCommand, oleDbConnection))
                using (var dataTable = new DataTable())
                {
                    adapter.FillSchema(dataTable, SchemaType.Source);
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            finally
            {
                if (File.Exists(schemaFile))
                {
                    File.Delete(schemaFile);
                }
            }
        }
