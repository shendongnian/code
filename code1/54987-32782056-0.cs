    static public DataTable Transpose(DataTable inputTable, List<string> newColumnNames)
    {
        DataTable outputTable = new DataTable();
        ///You should also verify if newColumnsNames.Count matches inputTable number of row
        //Creates the columns, using the provided column names.
        foreach (var newColumnName in newColumnNames)
        {
            outputTable.Columns.Add(newColumnName, typeof(string));
        }
        foreach (DataColumn inputColumn in inputTable.Columns)
        {
            //For each old column we generate a row in the new table
            DataRow newRow = outputTable.NewRow();
            //Looks in the former header row to fill in the first column
            newRow[0] = inputColumn.ColumnName.ToString();
            int counter = 1;
            foreach (DataRow row in inputTable.Rows)
            {
                newRow[counter] = row[inputColumn.ColumnName].ToString();
                counter++;
            }
            outputTable.Rows.Add(newRow);
        }
        return outputTable;
    }
