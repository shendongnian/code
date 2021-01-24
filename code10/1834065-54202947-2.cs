    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        if (_previousSelectedRow == indexPath)
            return;
    
    	base.RowSelected(tableView, indexPath);
    
        var cell = tableView.CellAt(indexPath);
        var previousSelectedCell = tableView.CellAt(_previousSelectedRow);
    
        InvokeOnMainThread(() =>
        {
            cell.Accessory = UITableViewCellAccessory.Checkmark;
            previousSelectedCell.Accessory = UITableViewCellAccessory.None;
        });
    
        _previousSelectedRow = indexPath;
    }
