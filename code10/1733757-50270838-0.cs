    void MoveFocusToLast(GridControl grid, string fieldName, object value) {
        for (int i = grid.VisibleRowCount - 1; i >= 0; i--) {
            var handle = grid.GetRowHandleByVisibleIndex(i);
            var currentValue = grid.GetCellValue(handle, fieldName);
            if (currentValue != null && currentValue.Equals(value)) {
                grid.View.FocusedRowHandle = handle;
                return;
            }
        }
    }
