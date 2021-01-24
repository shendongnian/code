    [HttpPost]
        public HttpResponseMessage DownloadFile(int fileId)
        {
            var user = GetUser();
            var fileContent = NoticesMethods.GetNoticeFile(fileId, user);
    
            using (Globals.WebAppsImpersonator())
            {
                if (fileContent.Count > 0)
                {
                    using (var mem = new MemoryStream())
                    using (var reader = new StreamReader(mem))
                    using (var writer = new StreamWriter(mem))
                    using (var csvWriter = new CsvWriter(writer))
                    {
                        csvWriter.Configuration.Delimiter = ",";
                        csvWriter.WriteField("File ID");
                        csvWriter.WriteField("Account");
                        csvWriter.WriteField("Move Date");
                        csvWriter.NextRecord();
                        foreach (var row in fileContent)
                        {
                            csvWriter.WriteField("\"" + row.FileId + "\"");
                            csvWriter.WriteField("\"" + row.Account + "\"");
                            csvWriter.WriteField("\"" + row.MoveDate + "\"");
                            csvWriter.NextRecord();
                        }
                        writer.Flush();
                        mem.Position = 0;
                        var file = reader.ReadToEnd();
                        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                        result.Content = new StringContent(file);
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                        result.Content.Headers.ContentDisposition.FileName = "Notice.csv";
                        return result;
                    }
                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
