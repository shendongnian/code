    public static bool UrlExists(string file)
        {
            bool exists = false;
            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(file);
            request.Method = "HEAD";
            request.Timeout = 5000; // milliseconds
            request.AllowAutoRedirect = false;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                if(response.StatusCode == HttpStatusCode.OK)
                    exists = true;
            }
            catch (WebException ex)
            {
                exists = false;
            }
            finally
            {
                // close your response.
                if (response != null)
                {
                    response.Close();
                }
            }
            return exists;
        }
