        int multilineht = 0;
        private void CustGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            multilineht = CustGridView.Rows[CustGridView.CurrentCell.RowIndex].Height;
            CustGridView.AutoResizeRow(CustGridView.CurrentCell.RowIndex, DataGridViewAutoSizeRowMode.AllCells);
        }
        private void CustGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CustGridView.Rows[CustGridView.CurrentCell.RowIndex].Height = multilineht;
        }
