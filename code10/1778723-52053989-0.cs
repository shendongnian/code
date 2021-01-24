     if (url.StartsWith("https"))
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = timeout;
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "text/xml;charset=UTF-8";
            request.Headers.Set("SOAPAction", soapAction);
            try
            {
                using (Stream stream = request.GetRequestStream())
                {
                    byte[] datas = Encoding.UTF8.GetBytes(soapXml);
                    stream.Write(datas, 0, datas.Length);
                    stream.Close();
                }
                var response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        var reader = new StreamReader(stream);
                        return System.Web.HttpUtility.HtmlDecode(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return string.Empty;
