        [HttpGet]
        public HttpResponseMessage GetExcel()
        {
            using (var p = new OfficeOpenXml.ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("My WorkSheet");
                ws.Cells["A1"].Value = "A1";
                var stream = new System.IO.MemoryStream(p.GetAsByteArray());
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(stream)
                };
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"myworkbook.xlsx"
                };
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentLength = stream.Length;
                return result;
            }
        }
