    private void Form1_Load(object sender, EventArgs e) {
      for (int i = 0; i < 10; i++) {
        dataGridView1.Rows.Add("C0R" + i, "C1R" + i, "C2R" + i);
      }
    }
    private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
      int row = dataGridView1.CurrentCell.RowIndex;
      int col = dataGridView1.CurrentCell.ColumnIndex;
      List<string> grr = GetSurroundingCells(row, col);
      textBox1.Text = "--- Cell a row: " + row + " col: " + col + " Value: " + GetCellValue(row, col) + Environment.NewLine;
      foreach (string item in grr) {
        textBox1.Text += item + Environment.NewLine;
      }
    }
