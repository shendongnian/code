    private static void SetConnectionInfo(ReportClass report, string ReportServer, string ReportDatabase)
    {
        TableLogOnInfo tInfo = new TableLogOnInfo();
        ConnectionInfo connectionInfo = tInfo.ConnectionInfo;
        connectionInfo.IntegratedSecurity = true;
        connectionInfo.ServerName = ReportServer;
        connectionInfo.DatabaseName = ReportDatabase;
        foreach (Table t in report.Database.Tables)
        {
            t.ApplyLogOnInfo(tInfo);
        }
        foreach (ReportClass subReport in report.Subreports)
        {
            SetConnectionInfo(subReport, ReportServer, ReportDatabase);
        }
    }
