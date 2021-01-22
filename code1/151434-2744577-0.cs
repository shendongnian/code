    public static List<T> GetListFromDataTable<T>(DataSet dataSet, string tableName, string rowName)
    {
        // Find out how many rows are in your table and create an aray of that length
        int count = dataSet.Tables[tableName].Rows.Count;
        List<T> values = new List<T>();
        // Loop through the table and row and add them into the array
        for (int i = 0; i < count; i++)
        {
            values.Add((T)dataSet.Tables[tableName].Rows[i][rowName]);
        }
        return values;
    }
