    private static DataTable CreateTableFromReportDataColumns(Report report)
    {
        DataTable table = new DataTable();
        HashSet<String> colsToAdd = new HashSet<String> { "DataStream" };
        foreach (ReportData reportData in report.ReportDatas)
        {
            foreach (var column in reportData.ReportDataColumns)
            {
                if (!String.IsNullOrEmpty(column.Name))
                    colsToAdd.Add(column.Name);
            }
        }
        foreach (string col in colsToAdd)
        {
            table.Columns.Add(col);
        }
        return table;
    }
