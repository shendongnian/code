     private void updateExcel_Click(object sender, EventArgs e) {
      for (int i = 0; i < dataGridView1.RowCount - 1; i++) {
        if (!RowIsEmpty(i)) {
          dataGridView1[2, i].Value = ConsigneeCombo.Text;
        }
      }
    }
    private bool RowIsEmpty(int rowIndex) {
      for (int i = 0; i < dataGridView1.ColumnCount; i++) {
        if (dataGridView1.Rows[rowIndex].Cells[i].Value != null &&
            dataGridView1.Rows[rowIndex].Cells[i].Value.ToString() != "") {
          return false;
        }
      }
      return true;
    }
