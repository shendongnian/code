                TableLogOnInfos TableLogOnInfos = new TableLogOnInfos();
                TableLogOnInfo TableLogOnInfo = new TableLogOnInfo();
                ConnectionInfo ConnectionInfo = new ConnectionInfo();
                Tables Tables;
                ConnectionInfo.ServerName = "ServerName";
                ConnectionInfo.DatabaseName = "Database";
                ConnectionInfo.UserID = "UserId";
                ConnectionInfo.Password = "Password";
                ReportDocument report = new ReportDocument();
                string reportPath = Server.MapPath("~/CrystalReport Path");
                report.Load(reportPath);
                Tables = report.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in Tables)
                {
                    TableLogOnInfo = table.LogOnInfo;
                    TableLogOnInfo.ConnectionInfo = ConnectionInfo;
                    table.ApplyLogOnInfo(TableLogOnInfo);
                }
                CrystalReportViewer1.RefreshReport();
                CrystalReportViewer1.ReportSource = report;
