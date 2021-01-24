        private void OnCellMouseClick(object sender, DataGridViewCellMouseEventArgs cellMouseEventArgs)
        {
            if (cellMouseEventArgs.RowIndex < 0 || cellMouseEventArgs.ColumnIndex < 0)
            {
                return;
            }
            var cellRef = _dataGridView[cellMouseEventArgs.ColumnIndex, cellMouseEventArgs.RowIndex];
            if (cellRef == null || cellRef.IsInEditMode || cellRef.ReadOnly)
            {
                return;
            }
            _dataGridView.BeginEdit(false);
            if (!(cellRef is DataGridViewComboBoxCell))
            {
                return;
            }
            var editingControl = DataGridView.EditingControl as DataGridViewComboBoxEditingControl;
            if (editingControl != null)
            {
                editingControl.DroppedDown = true;
            }
        }
