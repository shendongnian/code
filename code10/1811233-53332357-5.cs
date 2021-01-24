    private void btnSave_Click(object sender, EventArgs e) {
      StringBuilder sb = new StringBuilder();
      int RowCount = dgvCsv1.RowCount;
      int ColumnCount = dgvCsv1.ColumnCount;
      // get column headers
      for (int currentCol = 0; currentCol < ColumnCount; currentCol++) {
        sb.Append(dgvCsv1.Columns[currentCol].Name);
        if (currentCol < ColumnCount - 1) {
          sb.Append(",");
        }
        else {
          sb.AppendLine();
        }
      }
      // get the rows data
      for (int currentRow = 0; currentRow < RowCount; currentRow++) {
        if (!dgvCsv1.Rows[currentRow].IsNewRow) {
          for (int currentCol = 0; currentCol < ColumnCount; currentCol++) {
            if (dgvCsv1.Rows[currentRow].Cells[currentCol].Value != null) {
              sb.Append(dgvCsv1.Rows[currentRow].Cells[currentCol].Value.ToString());
            }
            if (currentCol < ColumnCount - 1) {
              sb.Append(",");
            }
            else {
              sb.AppendLine();
            }
          }
        }
      }
      textBoxExport.Text = sb.ToString();
      System.IO.File.WriteAllText(@"D:\Test\DGV_CSV_EXPORT.csv", sb.ToString());
    }
