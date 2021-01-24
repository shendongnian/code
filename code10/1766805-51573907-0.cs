    crpQLVT rpt = new crpQLVT();
    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-FFIKNAO\SQLEXPRESS;Initial Catalog=QLVT;Integrated Security=True";);
    conn.Open();
    SqlDataAdapter dap = new SqlDataAdapter("Select * from ThanhPhan", conn);
    DataSet ds = new DataSet();
    dap.Fill(ds);
    rpt.SetDataSource(ds.Tables[0]);
    crystalReportViewer1.ReportSource = rpt;
    crystalReportViewer1.Refresh();
