    private DataTable GetFilterTable() {
      DataTable filterTable = ((DataTable)dgv1.DataSource).Clone();
      dgv1.DataSource = gridTable;
      int targetValue = -1;
      if (int.TryParse(textBox1.Text, out targetValue)) {
        foreach (DataGridViewRow row in dgv1.Rows) {
          DataRowView dataRow = (DataRowView)row.DataBoundItem;
          if (dataRow != null) {
            if (TargetIsInRange(targetValue, dataRow)) {
              filterTable.Rows.Add(dataRow.Row.ItemArray[0]);
            }
          }
        }
      }
      return filterTable;
    }
