        public static void CrystalReportLogOn(ReportDocument reportParameters,
                                              string serverName,
                                              string databaseName,
                                              string userName,
                                              string password)
        {
            TableLogOnInfo logOnInfo;
            ReportDocument subRd;
            Sections sects;
            ReportObjects ros;
            SubreportObject sro;
            if (reportParameters == null)
            {
                throw new ArgumentNullException("reportParameters");
            }
            try
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table t in reportParameters.Database.Tables)
                {
                    logOnInfo = t.LogOnInfo;
                    logOnInfo.ReportName = reportParameters.Name;
                    logOnInfo.ConnectionInfo.ServerName = serverName;
                    logOnInfo.ConnectionInfo.DatabaseName = databaseName;
                    logOnInfo.ConnectionInfo.UserID = userName;
                    logOnInfo.ConnectionInfo.Password = password;
                    logOnInfo.TableName = t.Name;
                    t.ApplyLogOnInfo(logOnInfo);
                    t.Location = t.Name;
                }
            }
            catch
            {
                throw;
            }
            sects = reportParameters.ReportDefinition.Sections;
            foreach (Section sect in sects)
            {
                ros = sect.ReportObjects;
                foreach (ReportObject ro in ros)
                {
                    if (ro.Kind == ReportObjectKind.SubreportObject)
                    {
                        sro = (SubreportObject)ro;
                        subRd = sro.OpenSubreport(sro.SubreportName);
                        try
                        {
                            foreach (CrystalDecisions.CrystalReports.Engine.Table t in subRd.Database.Tables)
                            {
                                logOnInfo = t.LogOnInfo;
                                logOnInfo.ReportName = reportParameters.Name;
                                logOnInfo.ConnectionInfo.ServerName = serverName;
                                logOnInfo.ConnectionInfo.DatabaseName = databaseName;
                                logOnInfo.ConnectionInfo.UserID = userName;
                                logOnInfo.ConnectionInfo.Password = password;
                                logOnInfo.TableName = t.Name;
                                t.ApplyLogOnInfo(logOnInfo);
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }
