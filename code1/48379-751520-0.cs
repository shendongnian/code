        public static string WebPageRead(string url)
        {
            string content = String.Empty;
            if (!String.IsNullOrEmpty(url))
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                if (request != null)
                {
                    request.Method = "GET";
                    request.KeepAlive = false;
                    request.ProtocolVersion = HttpVersion.Version10;
                    try
                    {
                        using (WebResponse response = request.GetResponse())
                        {
                            using (Stream stream = response.GetResponseStream())
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    content = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        throw exc;
                    }
                }
            }                    
            return content;
        }
