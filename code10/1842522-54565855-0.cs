    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit") {
        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
        dataGridView1.ReadOnly = false;
        InEditMode1 = true;
      }
    }
    private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e) {
      if (InEditMode1) {
        dataGridView1.ReadOnly = true;
        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        InEditMode1 = false;
      }
    }
