    string[] TobeDistinct = {"Name","City","State"};
    DataTable dtDistinct = GetDistinctRecords(DTwithDuplicate, TobeDistinct);
     
    //Following function will return Distinct records for Name, City and State column.
    public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
    {
        DataTable dtUniqRecords = new DataTable();
        dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
        return dtUniqRecords;
    }
