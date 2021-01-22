    public void ImportSpreadsheet(string path)
    {
        string extendedProperties = "Excel 12.0;HDR=YES";
        string connectionString = string.Format(
            CultureInfo.CurrentCulture,
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"{1}\"",
            path,
            extendedProperties);
    
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Worksheet1$]";
                connection.Open();
    
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                using (DataSet columnDataSet = new DataSet())
                using (DataSet dataSet = new DataSet())
                {
                    columnDataSet.Locale = CultureInfo.CurrentCulture;
                    adapter.Fill(columnDataSet);
    
                    if (columnDataSet.Tables.Count == 1)
                    {
                        var worksheet = columnDataSet.Tables[0];
    
                        // Now that we have a valid worksheet read in, with column names, we can create a
                        // new DataSet with a table that has preset columns that are all of type string.
                        // This fixes a problem where the OLEDB provider is trying to guess the data types
                        // of the cells and strange data appears, such as scientific notation on some cells.
                        dataSet.Tables.Add("WorksheetData");
                        DataTable tempTable = dataSet.Tables[0];
    
                        foreach (DataColumn column in worksheet.Columns)
                        {
                            tempTable.Columns.Add(column.ColumnName, typeof(string));
                        }
    
                        adapter.Fill(dataSet, "WorksheetData");
    
                        if (dataSet.Tables.Count == 1)
                        {
                            worksheet = dataSet.Tables[0];
    
                            foreach (var row in worksheet.Rows)
                            {
                                // TODO: Consume some data.
                            }
                        }
                    }
                }
            }
        }
    }
