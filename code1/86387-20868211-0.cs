    private bool checkURL(string url)
            {
                bool pageExists = false;
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = WebRequestMethods.Http.Head;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    pageExists = response.StatusCode == HttpStatusCode.OK;
                }
                catch (Exception e)
                {
                    //Do what ever you want when its no working...
                    //Response.Write( e.ToString());
                }
                return pageExists;
            }
