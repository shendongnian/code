    private void yourGrid_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
    {
            GridDataCellElement cell = sender as GridDataCellElement;
            if (cell != null)
            {
                GridViewRowInfo rowInfo = cell.RowInfo;
                string columnHeaderName = CommonMethods.GetStringValue(rowInfo.Cells[cell.ColumnIndex].ColumnInfo.UniqueName.ToLower());
                if (columnHeaderName.ToLower().Equals("usagetype"))
                {
                    e.ToolTipText = CommonMethods.GetStringValue(cell.Value);
                }
            }
        }
