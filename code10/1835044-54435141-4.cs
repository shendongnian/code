    private void ResizeColumns()
    {
        // Calculate the minimum width for column2 based on content and Grid width
        item2Column.MinWidth = 0;
        item2Column.Width = new DataGridLength(1, DataGridLengthUnitType.SizeToCells);
        var sizeToCellsWidth = item2Column.ActualWidth;
        item2Column.MinWidth = Math.Max(dataGrid.ActualWidth - item1Column.ActualWidth,
            sizeToCellsWidth);
        // This is to deal with the precision issue for triggering the horizontal scroll bar.
        // The default behavior generated a condition where the scroll bar always was present
        // even when it wasn't necessary.
        if (Math.Abs(item1Column.ActualWidth + item2Column.ActualWidth - dataGrid.ActualWidth)
            <= 0)
        {
            dataGrid.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }
        else
        {
            dataGrid.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        }
    }
