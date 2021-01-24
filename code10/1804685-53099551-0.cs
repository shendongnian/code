    ReportDocument rptDoc = new ReportDocument();
    protected void Page_Init(object sender, EventArgs e)
    {
         CrystalReportViewer1.ReportSource = rptDoc;
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dsfeeEarnings ds = new dsfeeEarnings();
    
        rptDoc.Load(Server.MapPath("FeeEarningsReport.rpt"));
        rptDoc.SetDataSource(ds);
        dt = getFeeEarnings1();
        ds.Tables[0].Merge(dt);
    }
