    public void subReportProccessingFunc(object sender, SubreportProcessingEventArgs e)
    {
       sqls_Summary_Months.SelectParameters["LeaseID"].DefaultValue = 
       e.Parameters["prmLeaseID"].Values.First();
       e.DataSources.Add(new ReportDataSource("dsLeaseCalculationsMonths", 
       sqls_Summary_Months));
    
       this.rep_Main.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(subReportProccessingFunc1);
    }
    
    public void subReportProccessingFunc1(object sender, SubreportProcessingEventArgs e)
    {
       sqls_Summary_ViewMonth.SelectParameters["LeaseID"].DefaultValue = e.Parameters["prmLeaseID"].Values.First();
       sqls_Summary_ViewMonth.SelectParameters["Month"].DefaultValue = e.Parameters["prmMonth"].Values.First();
       e.DataSources.Add(new ReportDataSource("dsLeaseCalculationsViewMonth", sqls_Summary_ViewMonth));
    }
