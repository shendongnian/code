    private static DataTable CreateTableFromReportDataColumns(Report report)
    {
        HashSet<string> uniqueNames = new HashSet<string> { "DataStream" };
                    
        DataTable table = new DataTable();
    
        foreach (ReportData reportData in report.ReportDatas)
        {
            foreach (var dataColumn in reportData.ReportDataColumns)
            {
                if (!String.IsNullOrEmpty(dataColumn.Name))
                {
                    if (uniqueNames.Add(dataColumn.Name))
                    {
                        table.Columns.Add(dataColumn.Name);
                    }
                }
            }
        }
    
        return table;
    }
