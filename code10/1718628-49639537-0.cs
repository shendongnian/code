    TableCellProperties cellOneProperties = new TableCellProperties();
    cellOneProperties.Append(new HorizontalMerge()
    {
    	Val = MergedCellValues.Restart
    });
    
    TableCellProperties cellTwoProperties = new TableCellProperties();
    cellTwoProperties.Append(new HorizontalMerge()
    {
    	Val = MergedCellValues.Continue
    });
    
    cell1.Append(cellOneProperties);
    cell2.Append(cellTwoProperties);
