            dtGrid.SelectionChanged += DataGridView_SelectionChanged;
            this.dtGrid.DataSource = GetListOfEntities;
            dtGrid.CellValueChanged += DataGridView_CellValueChanged;
        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGrid.Rows[e.RowIndex];
            SetRowProperties(row);
        }
        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var rowsCount = dtGrid.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return;
            var row = dtGrid.SelectedRows[0];
            if (row == null) return; 
            ResolveActionsForRow(row);
        }
