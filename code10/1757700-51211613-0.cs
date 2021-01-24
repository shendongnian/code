    public DataTable convertTable(DataTable inputTable, int columnNameIndex = 0, int columnValueIndex = 1)
        {
            var outputTable = new DataTable();
            //Get the names of the columns for the output table
            var columnNames = inputTable.AsEnumerable().Where(x => x[columnNameIndex] != DBNull.Value && x[columnValueIndex] != DBNull.Value)
                                                            .Select(x => x[columnNameIndex].ToString()).Distinct().ToList();
            DataRow outputRow = outputTable.NewRow();
            //create the columns in the output table
            foreach (var columnName in columnNames)
            {
                outputTable.Columns.Add(new DataColumn(columnName));
            }
            //get all the rows in the input table
            var totalRows = inputTable.Rows.Count;
            //loop through the input table
            for (int n = 0; n < totalRows; n++)
            {
                //loop through each columnname for each row
                for (int i = 0; i < columnNames.Count; i++)
                {
                    //if it's the first loop we need a new row
                    if (i == 0)
                    {
                        outputRow = outputTable.NewRow();
                        outputRow[columnNames[i]] = inputTable.Rows[n][columnValueIndex].ToString();
                       //^^get the corresponding value from the input table
                    }
                    
                    //if it's the last loop all columns 
                    //have values added so add the row to the input table
                    if (i == columnNames.Count - 1)
                        outputTable.Rows.Add(outputRow);
                }
            }
            return outputTable;
    }
