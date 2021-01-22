    Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;`enter code here`
            string extension = string.Empty;
            DataSet dsGrpSum, dsActPlan, dsProfitDetails,
                dsProfitSum, dsSumHeader, dsDetailsHeader, dsBudCom = null;
    
        enter code here
    
    //This is optional if you have parameter then you can add parameters as much as you want
    ReportParameter[] param = new ReportParameter[5];
                param[0] = new ReportParameter("Report_Parameter_0", "1st Para", true);
                param[1] = new ReportParameter("Report_Parameter_1", "2nd Para", true);
                param[2] = new ReportParameter("Report_Parameter_2", "3rd Para", true);
                param[3] = new ReportParameter("Report_Parameter_3", "4th Para", true);
                param[4] = new ReportParameter("Report_Parameter_4", "5th Para");
                DataSet  dsData= "Fill this dataset with your data";
                ReportDataSource rdsAct = new ReportDataSource("RptActDataSet_usp_GroupAccntDetails", dsActPlan.Tables[0]);
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                viewer.LocalReport.ReportPath = "Reports/AcctPlan.rdlc"; //This is your rdlc name.
                viewer.LocalReport.SetParameters(param);
                viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                // byte[] bytes = viewer.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.          
                // System.Web.HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename= filename" + "." + extension);
                Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
                Response.Flush(); // send it to the client to download  
                Response.End();
