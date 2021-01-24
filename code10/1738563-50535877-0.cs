            public resp(HttpContext context)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            string formDataBoundary = String.Format("----------{0:N}", DateTime.Now.Ticks.ToString("x"));
            context.Response.ContentType = "multipart/form-data; boundary=" + formDataBoundary;
			context.Response.ContentEncoding = System.Text.Encoding.UTF8;
			context.Response.Headers.Add("X-data", "21-08-2017");
			context.Response.Headers.Add("X-numberfiles", "2");
			context.Response.Headers.Add("X-Id", "45625625EFA22AD");
			
			string[] files = new string[] { @"C:\Exemplo\Ficheiros\Fich1.txt", @"C:\Exemplo\Ficheiros\Fich2.txt" };
            Stream memStream = new MemoryStream();
            var boundarybytes = System.Text.Encoding.UTF8.GetBytes("--" + formDataBoundary + "\r\n");
            var endBoundaryBytes = System.Text.Encoding.UTF8.GetBytes("\r\n--" + formDataBoundary + "--");
			
			foreach (var FileName in files)
            {
                WriteFilePart(context, FileName, boundarybytes, memStream);
                boundarybytes = System.Text.Encoding.UTF8.GetBytes("\r\n--" + formDataBoundary + "\r\n");
            }
			
            memStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            using (Stream ResponseStream = context.Response.OutputStream)
            {
                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                ResponseStream.Write(tempBuffer, 0, tempBuffer.Length);
            }
			
        }
        private string WriteFilePart(HttpContext context, string FileName, byte[] boundarybytes, Stream memStream)
			{
			
			    string Tosend = "";
				Tosend = Tosend + "Content-Type: " + "text/plain" + "" + Environment.NewLine;
				Tosend = Tosend + "Content-Location: " + FileName + "" + Environment.NewLine;
				Tosend = Tosend + "Content-Disposition: attachment; filename=\"" + FileName + "\"" + Environment.NewLine;
				Tosend = Tosend + "Content-ID: " + FileName + "" + Environment.NewLine;
				Tosend = Tosend + Environment.NewLine;
			    memStream.Write(boundarybytes, 0, boundarybytes.Length);
				var headerbytes = System.Text.Encoding.UTF8.GetBytes(Tosend);
				memStream.Write(headerbytes, 0, headerbytes.Length);
			
				var filebyte = MultipartParser.Parse.FileToByteArray(FileName);  //converts file to byte[]
                memStream.Write(filebyte, 0, filebyte.Length);
				
			}
