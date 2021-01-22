    public static T Value<T>(this DataGridView dgv, int RowNo, string ColName)
    {
        if (!dgv.Columns.Contains(ColName))
            throw new ArgumentException("Column Name " + ColName + " doesnot exists in DataGridView.");
        return (T)Convert.ChangeType(dgv.Rows[RowNo].Cells[ColName].Value, typeof(T));
    }
    // Wherever you call the method:
    try
    {
        dataGridView.Value(rowNumber, columnName);
    }
    catch (ArgumentException)
    {
        // caught the exception
    }
