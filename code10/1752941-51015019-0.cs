    private void Form1_Load(object sender, EventArgs e) {
      FillGrid();
    }
    private void FillGrid() {
      for (int i = 0; i < 10; i++) {
        dataGridView1.Rows.Add("C0R" + i, "C1R" + i, "C2R" + i, "C3R" + i, "C4R" + i, i);
      }
    }
    private void button1_Click(object sender, EventArgs e) {
      DataGridViewRow row = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
      if (row.Cells[5].Value != null) {
        if (Int32.TryParse(row.Cells[5].Value.ToString(), out Int32 numvalue)) {
          if (numvalue == 0) {
            MessageBox.Show("Quantity/Value is not null and is equal to zero 0");
          }
          else {
            MessageBox.Show("Quantity/Value is not null, is a valid number but it is NOT equal to zero 0. Its value is: " + numvalue);
          }
        }
        else {
          MessageBox.Show("Quantity/Value is not null but it is not a valid number. Its value is: " + row.Cells[5].Value.ToString());
        }
      }
      else {
        MessageBox.Show("Quantity/Value is null...");
      }
    }
