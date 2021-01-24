    class StockListSourceClass : UITableViewSource
        {
           public event EventHandler<int> SelectButtonTapped;
            
    
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                StockTableViewCell cell = tableView.DequeueReusableCell(StockTableViewCell.Key) as StockTableViewCell ?? StockTableViewCell.Create();
                var item = stockLists[indexPath.Row];
                if (serialNoList.Contains(item.SerialNo))
                    cell.BindData(item, true, indexPath.Row);
                else
                    cell.BindData(item, false, indexPath.Row);
    
                cell.SelectButtonTapped -= OnCellSpeakButtonTapped;
                cell.SelectButtonTapped += OnCellSpeakButtonTapped;
    
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                cell.PreservesSuperviewLayoutMargins = false;
                cell.SeparatorInset = UIEdgeInsets.Zero;
                cell.LayoutMargins = UIEdgeInsets.Zero;
                cell.SetNeedsLayout();
                cell.LayoutIfNeeded();
                return cell;
            }
    
            void OnCellSpeakButtonTapped(object sender, int e)
            {
                var row = e;
                MarketSheetViewController.RowNo = (int)row;
                if (SelectButtonTapped != null)
                    SelectButtonTapped(sender, e);
            }
    }
