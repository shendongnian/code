    connectDB();
    ReportDocument cryRpt = new ReportDocument();
    DataSet ds;
    cmd = new SqlCommand("Select * from LeaveJO where IDno = '" + textBox1.Text + "'", conn);
    da = new SqlDataAdapter(cmd);
    ds = new DataSet();
    da.Fill(ds, "LeaveJO");
                cryRpt.Load(@"JOleave.rpt");
                cryRpt.SetDataSource(ds);
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
    TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
    ConnectionInfo crConnectionInfo = new ConnectionInfo();
    Tables CrTables;
    crConnectionInfo.ServerName = cs.serverName;
    crConnectionInfo.DatabaseName = cs.dbName;
    crConnectionInfo.UserID = cs.userID;
    crConnectionInfo.Password = cs.password;
    CrTables = cryRpt.Database.Tables;
    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
    {
        crtableLogoninfo = CrTable.LogOnInfo;
        crtableLogoninfo.ConnectionInfo = crConnectionInfo;
        CrTable.ApplyLogOnInfo(crtableLogoninfo);
    }
    cryRpt.Refresh();
    //  cryRpt.PrintToPrinter(2, true, 1, 2);
    crystalReportViewer1.ReportSource = cryRpt;
    crystalReportViewer1.Visible = true;
    cryRpt.Dispose();
    conn.Dispose();
