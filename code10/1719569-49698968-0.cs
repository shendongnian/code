    private void CommitChanges()
    {
        // mCustomer is a record from the CustomerRecords Linq DataTable
        var rowId = mCustomer.RowId;
        _dc.SubmitChanges();
        _dc.ClearCache();
        // After ClearCache, it seems I need to physically pull the data again:
        mCustomer = _dc.CustomerRecords.FirstOrDefault(c => c.RowId == rowId);
        // Use the new record to update the controls on the form
        LoadData(mCustomer);
    }
