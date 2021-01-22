    private static DataTable CreateTableFromReportDataColumns(Report report)
    {
        HashSet<string> uniqueNames = new HashSet<string> { null, "", "DataStream" };
                    
        DataTable table = new DataTable();
        table.Columns.Add("DataStream");
    
        foreach (ReportData reportData in report.ReportDatas)
        {
            foreach (var dataColumn in reportData.ReportDataColumns)
            {
                if (uniqueNames.Add(dataColumn.Name))
                {
                    table.Columns.Add(dataColumn.Name);
                }
            }
        }
    
        return table;
    }
