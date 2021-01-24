    public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
    {
            UINib nib = UINib.FromName("WorkCell", NSBundle.MainBundle);
            tableView.RegisterNibForCellReuse(nib, "workCellContainer");
            var cell = (WorkCell)tableView.DequeueReusableCell ("workCellContainer");
    
            return cell;
    }
