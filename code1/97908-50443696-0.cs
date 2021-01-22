                    rptTeacherTimeTable ttReport = new rptTeacherTimeTable();
                    DataTable dt = new DataTable();
                    dt = ObjclsT_TimeTable.GetTimeTableByClass(ClassID);
    
                    objReport = ttReport;
                    objReport.SetDataSource(dt);
                    objReport.SetParameterValue("RTitle", "Class Time Table");
                    objReport.SetParameterValue("STitle", "Teacher Time Table");
                    reportViewer.crystalReportViewer1.ReportSource = objReport;
                    reportViewer.crystalReportViewer1.Show();
                    reportViewer.Show();
