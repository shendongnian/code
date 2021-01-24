    while (dr.Read())
        {
             row = (DataGridViewRow)dgvGridView.Rows[0].Clone();
             row.Cells[dgvGridView.Columns["Key"].Index].Value = dr.GetValue(0).ToString();
             row.Cells[dgvGridView.Columns["Amount"].Index].Value = dr.GetValue(8).ToString();
            // This Line works...
            row.Cells[dgvGridView.Columns["Amount"].Index].Style = new DataGridViewCellStyle() { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight };
            
            dgvGridView.Rows.Add(row);
        }
    dgvGridView.Refresh();
