        protected override WebResponse GetWebResponse(WebRequest request)
        {
            try
            {
                return base.GetWebResponse(request);
            }
            catch (WebException)
            {
                HttpWebRequest httpWebRequest = request as HttpWebRequest;
                if (httpWebRequest != null && httpWebRequest.ServicePoint != null)
                    httpWebRequest.ServicePoint.CloseConnectionGroup(httpWebRequest.ConnectionGroupName);
                throw;
            }
        }
