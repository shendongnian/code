    namespace WindowsFormsApplication1
    {
        public static class FormUpload
        {
            private static string NewDataBoundary()
            {
                Random rnd = new Random();
                string formDataBoundary = "";
                while (formDataBoundary.Length < 15)
                {
                    formDataBoundary = formDataBoundary + rnd.Next();
                }
                formDataBoundary = formDataBoundary.Substring(0, 15);
                formDataBoundary = "-----------------------------" + formDataBoundary;
                return formDataBoundary;
            }
    
            public static HttpWebResponse MultipartFormDataPost(string postUrl, IEnumerable<Cookie> cookies, Dictionary<string, string> postParameters)
            {
                string boundary = NewDataBoundary();
    
                HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;
    
                // Set up the request properties
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=" + boundary;
                request.UserAgent = "PhasDocAgent 1.0";
                request.CookieContainer = new CookieContainer();
    
                foreach (var cookie in cookies)
                {
                    request.CookieContainer.Add(cookie);
                }
    
                #region WRITING STREAM
                using (Stream formDataStream = request.GetRequestStream())
                {
                    foreach (var param in postParameters)
                    {
                        if (param.Value.StartsWith("file://"))
                        {
                            string filepath = param.Value.Substring(7);
    
                            // Add just the first part of this param, since we will write the file data directly to the Stream
                            string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
                                boundary,
                                param.Key,
                                Path.GetFileName(filepath) ?? param.Key,
                                MimeTypes.GetMime(filepath));
    
                            formDataStream.Write(Encoding.UTF8.GetBytes(header), 0, header.Length);
    
                            // Write the file data directly to the Stream, rather than serializing it to a string.
    
                            byte[] buffer = new byte[2048];
    
                            FileStream fs = new FileStream(filepath, FileMode.Open);
    
                            for (int i = 0; i < fs.Length; )
                            {
                                int k = fs.Read(buffer, 0, buffer.Length);
                                if (k > 0)
                                {
                                    formDataStream.Write(buffer, 0, k);
                                }
                                i = i + k;
                            }
                            fs.Close();
                        }
                        else
                        {
                            string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n",
                                boundary,
                                param.Key,
                                param.Value);
                            formDataStream.Write(Encoding.UTF8.GetBytes(postData), 0, postData.Length);
                        }
                    }
                    // Add the end of the request
                    byte[] footer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                    formDataStream.Write(footer, 0, footer.Length);
                    request.ContentLength = formDataStream.Length;
                    formDataStream.Close();
                }
                #endregion
    
                return request.GetResponse() as HttpWebResponse;
            }
        }
    }
