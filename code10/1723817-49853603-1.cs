    private void dataGridSales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 2)
        {
            double price = Convert.ToDouble(dataGridSales.Rows[e.RowIndex].Cells[2].Value);
                dataGridSales.Columns[2].DefaultCellStyle
                                        .FormatProvider = CultureInfo.GetCultureInfo("en-US");
                dataGridSales.Columns[2].DefaultCellStyle.Format = String.Format("c");
        }
    }
