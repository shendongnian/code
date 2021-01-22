    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
        if (dataGridView1.Columns[e.ColumnIndex].Name == "Column3") {
            if (e.Value.ToString() == "0") {
                e.CellStyle.BackColor = Color.Red;
                e.Value = "False";
            }
        }
    }
