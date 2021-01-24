    private void DataGridView1_CellFormatting(object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        DataGridView dgv = (DataGridView)sender;
        if (dgv.Columns[e.ColumnIndex].Name == "Columnname" &&
            e.RowIndex >= 0 &&
            dgv["Columnname", e.RowIndex].Value is int)
        {
            switch ((int)dgv["TargetColumnName", e.RowIndex].Value)
            {
    
                    //Create custom display text/value here and assign to e.Value
                    string dataformatValue = //Create from database value;
                    e.Value = dataformatValue ;
                    e.FormattingApplied = true;
               
            }
        }
    }
