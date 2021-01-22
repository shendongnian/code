    var gridBoundColumns = Grid1.Columns.OfType<BoundField>();
    if(gridBoundColumns.Any(bf => bf.DataField.Equals(searchColumn.Name)) == false)
    {
        Grid1.Columns.Add(new BoundField{ ... });
    }
