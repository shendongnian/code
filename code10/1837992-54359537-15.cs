    private void AddGridColumn() {
      DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
      col.Name = "AgeRange";
      col.DataPropertyName = "AgeRange";
      col.HeaderText = "Age Range";
      dgv1.Columns.Add(col);
    }
