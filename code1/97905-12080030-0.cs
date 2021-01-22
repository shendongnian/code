             ReportDocument cryRpt = new ReportDocument();
             TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
             TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
             ConnectionInfo crConnectionInfo = new ConnectionInfo();
             Tables CrTables;
            string path = "C:/reportpath/report.rpt";
            cryRpt.Load(path);
            cryRpt.SetParameterValue("MyDate2", str2);
            cryRpt.SetParameterValue("MyDate", str1);
            crConnectionInfo.ServerName = "server";
            crConnectionInfo.DatabaseName = "DataBase";
            crConnectionInfo.UserID = "user";
            crConnectionInfo.Password = "password";
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh(); 
