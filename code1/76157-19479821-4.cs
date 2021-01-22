      public class MimePart
            {
                NameValueCollection _headers = new NameValueCollection();
                byte[] _header;
    
                public NameValueCollection Headers
                {
                    get { return _headers; }
                }
    
                public byte[] Header
                {
                    get { return _header; }
                }
    
                public long GenerateHeaderFooterData(string boundary)
                {
                    StringBuilder sb = new StringBuilder();
    
                    sb.Append("--");
                    sb.Append(boundary);
                    sb.AppendLine();
                    foreach (string key in _headers.AllKeys)
                    {
                        sb.Append(key);
                        sb.Append(": ");
                        sb.AppendLine(_headers[key]);
                    }
                    sb.AppendLine();
    
                    _header = Encoding.UTF8.GetBytes(sb.ToString());
    
                    return _header.Length + Data.Length + 2;
                }
    
                public Stream Data { get; set; }
            }
            
            public string Upload(string url, NameValueCollection requestParameters, params MemoryStream[] files)
            {
                using (WebClient req = new WebClient())
                {
                    List<MimePart> mimeParts = new List<MimePart>();
    
                    try
                    {
                        foreach (string key in requestParameters.AllKeys)
                        {
                            MimePart part = new MimePart();
    
                            part.Headers["Content-Disposition"] = "form-data; name=\"" + key + "\"";
                            part.Data = new MemoryStream(Encoding.UTF8.GetBytes(requestParameters[key]));
    
                            mimeParts.Add(part);
                        }
    
                        int nameIndex = 0;
    
                        foreach (MemoryStream file in files)
                        {
                            MimePart part = new MimePart();
                            string fieldName = "file" + nameIndex++;
    
                            part.Headers["Content-Disposition"] = "form-data; name=\"" + fieldName + "\"; filename=\"" + fieldName + "\"";
                            part.Headers["Content-Type"] = "application/octet-stream";
    
                            part.Data = file;
    
                            mimeParts.Add(part);
                        }
    
                        string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
                        req.Headers.Add(HttpRequestHeader.ContentType, "multipart/form-data; boundary=" + boundary);
    
                        long contentLength = 0;
    
                        byte[] _footer = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
    
                        foreach (MimePart part in mimeParts)
                        {
                            contentLength += part.GenerateHeaderFooterData(boundary);
                        }
    
                        //req.ContentLength = contentLength + _footer.Length;
    
                        byte[] buffer = new byte[8192];
                        byte[] afterFile = Encoding.UTF8.GetBytes("\r\n");
                        int read;
    
                        using (MemoryStream s = new MemoryStream())
                        {
                            foreach (MimePart part in mimeParts)
                            {
                                s.Write(part.Header, 0, part.Header.Length);
    
                                while ((read = part.Data.Read(buffer, 0, buffer.Length)) > 0)
                                    s.Write(buffer, 0, read);
    
                                part.Data.Dispose();
    
                                s.Write(afterFile, 0, afterFile.Length);
                            }
    
                            s.Write(_footer, 0, _footer.Length);
                            byte[] responseBytes = req.UploadData(url, s.ToArray());
                            string responseString = Encoding.UTF8.GetString(responseBytes);
                            return responseString;
                        }
                    }
                    catch
                    {
                        foreach (MimePart part in mimeParts)
                            if (part.Data != null)
                                part.Data.Dispose();
    
                        throw;
                    }
                }
            }
