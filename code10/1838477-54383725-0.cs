    private double Sum(DataGridView dgv, string ColumnName)
    {
        double sum = 0;
        foreach(DataGridViewRow row in dgv.Rows)
            sum += Convert.ToDouble(row.Cells[ColumnName].Value);
        return sum;
    }
