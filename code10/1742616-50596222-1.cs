    private void Searchvalue_TextChanged(object sender, EventArgs e) {
      dataGridView1.ClearSelection();
      var targetText = Searchvalue.Text;
      if (targetText != String.Empty) {
        foreach (DataGridViewRow row in dataGridView1.Rows) {
          if (!row.IsNewRow && row.Cells["Column1"].Value != null && row.Cells["Column1"].Value.ToString().Contains(targetText)) {
            row.Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
            break;  // remove this if you want to select all the rows that contain the text
          }
        }
      }
    }
