    protected void Dtg_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem row = (GridDataItem)e.Item;
        if (decimal.Parse(row["UniqueColumnName"].Text) > 0)
        {
            // iterate on cells
            for (int i = 0; i <= 6; i++)
                row.Cells[i].CssClass = "gridCellBoldRed";
        }
    }
