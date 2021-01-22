    RemoveDuplicatesRecords(yourDataTable);
    private DataTable RemoveDuplicatesRecords(DataTable dt)
    {
        var UniqueRows = dt.AsEnumerable().Distinct(DataRowComparer.Default);
        DataTable dt2 = UniqueRows.CopyToDataTable();
        return dt2;
    }
