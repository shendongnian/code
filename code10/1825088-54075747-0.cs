    private void DataGrid_OnSorting(object sender, DataGridSortingEventArgs e)
    {
        decimal runningTotal = 0.0M;
        //I have to maintain the sort order myself. If I let the control do it it will also resort the items again
        e.Column.SortDirection = e.Column.SortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
        IEnumerable<RegisterEntry> tempList = RegisterList;
        switch (e.Column.Header.ToString())
        {
            case "Payment":
                tempList = e.Column.SortDirection == ListSortDirection.Ascending ? tempList.OrderBy(item => item.Payment) : tempList.OrderByDescending(item => item.Payment);
                break;
            case "Transaction":
                tempList = e.Column.SortDirection == ListSortDirection.Ascending ? tempList.OrderBy(item => item.TransactionDate) : tempList.OrderByDescending(item => item.TransactionDate);
                break;
            case "Payee":
                tempList = e.Column.SortDirection == ListSortDirection.Ascending ? tempList.OrderBy(item => item.itemPayee) : tempList.OrderByDescending(item => item.itemPayee);
                break;
        }
        tempList = tempList
            .Select(item => new RegisterEntry()
            {
                Id = item.Id,
                AccountId = item.AccountId,
                TransactionDate = item.TransactionDate,
                ClearanceDate = item.ClearanceDate,
                Flag = item.Flag,
                CheckNumber = item.CheckNumber,
                itemPayee = item.itemPayee,
                itemCategory = item.itemCategory,
                Memo = item.Memo,
                itemState = item.itemState,
                Payment = item.Payment,
                Deposit = item.Deposit,
                RunningBalance = (runningTotal += (item.Deposit - item.Payment))
            }).ToList();
        RegisterList.ReplaceRange(tempList);
        // Set the event as Handled so it doesn't resort the items.
        e.Handled = true;
    }
