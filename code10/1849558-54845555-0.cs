    private void updateExcel_Click(object sender, EventArgs e) {
      for (int i = 0; i < dataGridView1.RowCount; i++) {
        if (!dataGridView1.Rows[i].IsNewRow &&
            dataGridView1.Rows[i].Cells[0].Value != null &&
            dataGridView1.Rows[i].Cells[0].Value.ToString() != "") {
          dataGridView1[2, i].Value = ConsigneeCombo.Text;
        }
      }
    }
