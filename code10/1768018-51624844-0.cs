    private void checkData(string s)            // check wether s in the list, add it if not, keep things sorted
    {
      if (data.Contains(s))
        return;
      data.Add(s);
      data.Sort();
      // now because each cell is independent... we have to update each data source! 
      UpdateCombos();
    }
    private void UpdateCombos() {
      foreach (DataGridViewRow row in theGrid.Rows) {
        if ((!row.IsNewRow) && (row.Cells[0].Value != null)) {
          string currentValue = row.Cells[0].Value.ToString();
          DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
          c.Value = currentValue;
          c.DataSource = data;
          row.Cells[0] = c;
        }
      }
    }
