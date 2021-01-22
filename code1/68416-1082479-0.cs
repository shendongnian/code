    internal void HandleSelectionForCellInput(DataGridCell cell, bool startDragging, bool allowsExtendSelect, bool allowsMinimalSelect)
    {
        DataGridSelectionUnit selectionUnit = SelectionUnit;
    
        // If the mode is None, then no selection will occur
        if (selectionUnit == DataGridSelectionUnit.FullRow)
        {
            // In FullRow mode, items are selected
            MakeFullRowSelection(cell.RowDataItem, allowsExtendSelect, allowsMinimalSelect);
        }
        else
        {
            // In the other modes, cells can be individually selected
            MakeCellSelection(new DataGridCellInfo(cell), allowsExtendSelect, allowsMinimalSelect);
        }
    
        if (startDragging)
        {
            BeginDragging();
        }
    }
