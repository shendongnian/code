    private void DgvStock_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
    {
        foreach (DataGridViewRow row in DgvStock.Rows)
        {
            int Qty = Convert.ToInt32(row.Cells[4].Value);
            if (Qty <= 10)
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.BackColor = Color.Red;
            }
    
    DateTime exp = Convert.ToDateTime(row.Cells["yourExpiryDateColumn"].Value);
            if (exp <= System.DateTime.Now)
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.BackColor = Color.Red;
            }
        }
    }
