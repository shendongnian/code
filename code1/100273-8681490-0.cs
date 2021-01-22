    void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
    {
        GridViewComboBoxColumn comboCol = e.Column as GridViewComboBoxColumn;
        if (comboCol != null)
        {
            DataTable source = comboCol.DataSource as DataTable;
            foreach (DataRow row in source.Rows)
            {
                if (row["ContractorID"].Equals(e.Value))
                {
                    MessageBox.Show(row["ContractorName"].ToString());
                    return;
                }
            }
        }
    }
