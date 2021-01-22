    private static DataTable CreateTableFromReportDataColumns(Report report) 
    { 
        DataTable table = new DataTable(); 
        table.Columns.Add("DataStream");
        IEnumerable<string> moreColumns = report.ReportDatas
          .SelectMany(z => z.ReportDataColumns)
          .Select(x => x.Name)
          .Where(s => s != null && s != "")
          .Distinct();
 
        foreach (string col in moreColumns) 
        { 
            table.Columns.Add(col); 
        } 
 
        return table; 
    } 
