    public void ScrollToRow(int theRow)
    {
        //
        // Expose the protected GridVScrolled method allowing you
        // to programmatically scroll the grid to a particular row.
        //
        if (DataSource != null)
        {
            GridVScrolled(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, theRow));
        }
    }
