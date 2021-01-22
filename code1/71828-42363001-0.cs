         public string SendFile(string filePath)
                {
                    WebResponse response = null;
                    try
                    {
                        string sWebAddress = "Https://www.address.com";
                        string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                        byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                        HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(sWebAddress);
                        wr.ContentType = "multipart/form-data; boundary=" + boundary;
                        wr.Method = "POST";
                        wr.KeepAlive = true;
                        wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                        Stream stream = wr.GetRequestStream();
                        string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
        
                        stream.Write(boundarybytes, 0, boundarybytes.Length);
                        byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(filePath);
                        stream.Write(formitembytes, 0, formitembytes.Length);
                        stream.Write(boundarybytes, 0, boundarybytes.Length);
                        string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                        string header = string.Format(headerTemplate, "file", Path.GetFileName(filePath), Path.GetExtension(filePath));
                        byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                        stream.Write(headerbytes, 0, headerbytes.Length);
        
                        FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        byte[] buffer = new byte[4096];
                        int bytesRead = 0;
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                            stream.Write(buffer, 0, bytesRead);
                        fileStream.Close();
        
                        byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                        stream.Write(trailer, 0, trailer.Length);
                        stream.Close();
        
                        response = wr.GetResponse();
                        Stream responseStream = response.GetResponseStream();
                        StreamReader streamReader = new StreamReader(responseStream);
                        string responseData = streamReader.ReadToEnd();
                        return responseData;
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    finally
                    {
                        if (response != null)
                            response.Close();
                    }
                }
