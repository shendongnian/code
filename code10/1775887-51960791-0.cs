    public HttpResponseMessage GenerateOrderReport(int orderID)
        {
            var reportName = ConfigurationManager.AppSettings["EmailAttachmentURLTemplate"];
            string activeDir = ConfigurationManager.AppSettings["EmailAttachmentSaveLocation"];
            string newPath = System.IO.Path.Combine(activeDir, ConfigurationManager.AppSettings["EmailAttachmentSaveFolder"]);
            var reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            var reportSource = new Telerik.Reporting.UriReportSource()
            {
                Uri = reportName
            };
            reportSource.Parameters.Add("OrderID", 141);
            reportSource.Parameters.Add("OrderMethodTypeID", 2);
            var deviceInfo = new System.Collections.Hashtable()
            {
                {"DocumentTitle", "Order Report" }
            };
            var result = reportProcessor.RenderReport("PDF", reportSource, deviceInfo);
            if (!result.HasErrors)
            {
                System.IO.Directory.CreateDirectory(newPath);
                string newFileName = "OrderReport.pdf";
                newPath = System.IO.Path.Combine(newPath, newFileName);
                FileStream fileStream = new FileStream(newPath, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
                fileStream.Close();
                HttpResponseMessage fileResult = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(newPath, FileMode.Open);
                fileResult.Content = new StreamContent(stream);
                fileResult.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                fileResult.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                fileResult.Content.Headers.ContentDisposition.FileName = newFileName;
                return fileResult;
            }
            else
            {
                throw new Exception("Report contains errors. " + result.Errors[0].Message);
            }
        }
