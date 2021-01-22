    private void ResizeGridViewColumn(GridViewColumn column)
    {
        if (double.IsNaN(column.Width))
        {
            column.Width = column.ActualWidth;
        }
    
        column.Width = double.NaN;
    }
