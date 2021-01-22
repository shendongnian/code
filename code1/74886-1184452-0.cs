            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                request.Timeout = 20000;
                using (var response = request.GetResponse())
                {
                    //Do something with response.
                }
                
                request = (HttpWebRequest)WebRequest.Create("http://www.bing.com");
                using (var response = request.GetResponse())
                {
                    //Do somehing with response
                }
            }
            catch (Exception ex)
            {
                //do something
            }
            finally
            {
            }
