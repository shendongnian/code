        private static string DoGET(string URL,NameValueCollection QueryStringParameters = null, NameValueCollection RequestHeaders = null)
        {
            string ResponseText = null;
            using (WebClient client = new WebClient())
            {
                try
                {
                    if (RequestHeaders != null)
                    {
                        if (RequestHeaders.Count > 0)
                        {
                            foreach (string header in RequestHeaders.AllKeys)
                                client.Headers.Add(header, RequestHeaders[header]);
                        }
                    }
                    if (QueryStringParameters != null)
                    {
                        if (QueryStringParameters.Count > 0)
                        {
                            foreach (string parm in QueryStringParameters.AllKeys)
                                client.QueryString.Add(parm, QueryStringParameters[parm]);
                        }
                    }
                    byte[] ResponseBytes = client.DownloadData(URL);
                    ResponseText = Encoding.UTF8.GetString(ResponseBytes);
                }
                catch (WebException exception)
                {
                    if (exception.Response != null)
                    {
                        var responseStream = exception.Response.GetResponseStream();
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                Response.Write(reader.ReadToEnd());
                            }
                        }
                    }
                }
            }
            return ResponseText;
        }
