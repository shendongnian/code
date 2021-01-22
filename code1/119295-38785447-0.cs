    dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
                if (dataGridView1.Columns[5].Index == e.ColumnIndex && e.RowIndex >= 0 && dataGridView1[5, e.RowIndex].Value.ToString() != "0")
                {
                    e.CellStyle.BackColor = Color.PaleGreen;
                }
        }
