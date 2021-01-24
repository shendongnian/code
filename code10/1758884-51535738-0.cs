    public string Get(string resource)
        {
            string url = BuildResourceUrl(resource);
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebRequest req = WebRequest.Create(url);
                req.Method = "GET";
                req.ContentType = "application/json";
                req.Headers.Add("X-Shopify-Access-Token", _apiPassword);
                WebResponse response = req.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                return responseFromServer;
            }
            catch (WebException ex)
            {
                string response;
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    response = reader.ReadToEnd();
                }
                throw ex;
            }
        }
