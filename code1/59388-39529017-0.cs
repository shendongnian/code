        public bool IsValidUrl(string url)
        {
             try
             {
                 var request = WebRequest.Create(url);
                 request.Timeout = 5000;
                 request.Method = "HEAD";
 
                 using (var response = (HttpWebResponse)request.GetResponse())
                 {
                    response.Close();
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (Exception exception)
            { 
                return false;
            }
       }
