            private void GetRequestResponse()
        {
            if (null == FileStream)
            {
                System.IO.Stream stream;
                WebResponse webResponse;
                try
                {
                    webResponse = Request.GetResponse();
                }
                catch (WebException web)
                {
                    webResponse = web.Response;
                }
                if (null != webResponse)
                {
                    stream = webResponse.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    string str;
                    Response = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        Response += str;
                    }
                    webResponse.Close();
                }
                else
                {
                    throw new Exception("Error retrieving server response");
                }
            }
        }
