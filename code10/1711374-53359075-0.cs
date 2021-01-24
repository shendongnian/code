     private void RenderReportToClient()
     {
         //set credentials
         RSExecuteProxy.ReportExecutionService rs = new RSExecuteProxy.ReportExecutionService();
        rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
     
        RSProxy.ReportingService2005 rsInfo = new RSProxy.ReportingService2005();
        rsInfo.Credentials = System.Net.CredentialCache.DefaultCredentials;
         // init render args
        byte[] result = null;
        string reportPath = rptViewer.ServerReport.ReportPath;
       string format = "PDF";
        string historyId = null;
         string encoding;
        string mimeType;
         string extension;
        RSExecuteProxy.Warning[] warnings = null;
         string[] streamIDs = null;
         //init exec info
         RSExecuteProxy.ExecutionInfo execInfo = new RSExecuteProxy.ExecutionInfo();
         RSExecuteProxy.ExecutionHeader execHeader = new RSExecuteProxy.ExecutionHeader();
         rs.ExecutionHeaderValue = execHeader;
         //get report
         execInfo = rs.LoadReport(reportPath, historyId);
         String SessionId = rs.ExecutionHeaderValue.ExecutionID;
        //get parameter info
         ReportParameterInfoCollection parameters = rptViewer.ServerReport.GetParameters();
        //figure out how many parameters we will have 
         //those with multi-value will need there own ParameterValue in the array
        int paramCount = 0;
         foreach (ReportParameterInfo pramInfo in parameters)
         {
             paramCount += pramInfo.Values.Count;
        }
     
        RSExecuteProxy.ParameterValue[] prams = new SSRSWeb.RSExecuteProxy.ParameterValue[paramCount];
        int currentPramPosition = 0;
      
         //set pram values
         foreach (ReportParameterInfo pramInfo in parameters)
         {
             foreach (string pramValue in pramInfo.Values)
             {
               prams[currentPramPosition] = new SSRSWeb.RSExecuteProxy.ParameterValue();
                prams[currentPramPosition].Label = pramInfo.Name;
                prams[currentPramPosition].Name = pramInfo.Name;
             prams[currentPramPosition].Value = pramValue;
                currentPramPosition++;
            }
          }
     
           rs.SetExecutionParameters(prams, "en-US");
      
          //build the device settings  (A4 8.3 × 11.7)
           string deviceInfo = string.Format("<DeviceInfo><PageHeight>{0}</PageHeight><PageWidth>{1}</PageWidth></DeviceInfo>", "11.7in", "8.3in");
     
        //get report bytes
         result = rs.Render(format, deviceInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);
      
           Response.ClearContent();
          Response.AppendHeader("Content-Disposition", "inline;filename=report.pdf");
           Response.AppendHeader("content-length", result.Length.ToString());
         Response.ContentType = "application/pdf";
        Response.BinaryWrite(result);
        Response.Flush();
         Response.Close();
       }
