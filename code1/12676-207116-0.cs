    if (!Page.IsPostBack)
    {
        if (Request.QueryString.Get("id") == "5")
        {
            string publication = Request.QueryString.Get("pub");
            DateTime date = DateTime.Parse(Request.QueryString.Get("date"));
            int pages = int.Parse(Request.QueryString.Get("pages"));
            int sort = int.Parse(Request.QueryString.Get("sort"));
            // fixed the statement below to key off of session
            if (Session["Record"] == null)
            {
                reportpath = Server.MapPath("IssuesReport.rpt");
                rpt.Load(reportpath);
                Session["Record"] = RetrievalProcedures.IssuesReport(date, publication, pages);
             }
             rpt.SetDataSource((DataTable)Session["Record"]);
             CrystalReportViewer1.ReportSource = rpt;
             // ....
        }
    }       
