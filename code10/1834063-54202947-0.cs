    public class EntryTypesTableSource : MvxTableViewSource
	{
        private bool _isFirst = true;
        private NSIndexPath _previousSelectedRow = null;
        public HomeTableViewSource(UITableView tableView) : base(tableView)
		{
			tableView.RegisterNibForCellReuse(EntryTypeCell.Nib, EntryTypeCell.Key);
            tableView.AllowsMultipleSelection = false;
            tableView.AllowsSelection = true;
		}
		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
			var cell = tableView.DequeueReusableCell(EntryTypeCell.Key, indexPath);
            if (_isFirst)
            {
                cell.Accessory = UITableViewCellAccessory.Checkmark;
                _previousSelectedRow = indexPath;
                _isFirst = false;
            }
			return cell;
		}
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            if (_previousSelectedRow == indexPath)
                return;
			base.RowSelected(tableView, indexPath);
            var cell = tableView.CellAt(indexPath);
            cell.Accessory = UITableViewCellAccessory.Checkmark;
            var previousSelectedCell = tableView.CellAt(_previousSelectedRow);
            previousSelectedCell.Accessory = UITableViewCellAccessory.None;
            _previousSelectedRow = indexPath;
        }
    }
