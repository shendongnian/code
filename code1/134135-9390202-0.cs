        if (Session["UID"].ToString() == "0" || Session["UID"].ToString() == "" && Session["CID"].ToString() == "0" || Session["CID"].ToString() == "")
        {
            Response.Redirect("Login.aspx");
        }
        else
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (IsPostBack)
        {
            lblStatus.Text = "";
            funtion();
        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        ReportDocument crystalReport = new ReportDocument();
        this.CrystalReportViewer1.Dispose();
        this.CrystalReportViewer1 = null;
        crystalReport.Close();
        crystalReport.Dispose();
        GC.Collect();
    }
