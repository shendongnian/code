    foreach (DataGridViewColumn c in dataGridView1.Columns)
    {
        if (c.ValueType == typeof(double))
        {
            c.DefaultCellStyle.Format = "C2";
            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
