    string _serverURL = https://localhost:9443/ccm; 
            string _resourceURL = "https://localhost:9443/ccm/rootservices";
            string mediatype = "application/xml";
            string username = "username";                                    
            string password = "password";
            try
            {
                CookieContainer _cookies = new CookieContainer();//create cookie container
                HttpWebRequest documentGet = (HttpWebRequest)WebRequest.Create(_resourceURL);
                documentGet.Method = "GET"; //method
                documentGet.CookieContainer = _cookies; //set container for HttpWebRequest 
                documentGet.Accept = mediatype;
                documentGet.Headers.Set("OSLC-Core-Version", "3.0"); //for RTC 3.0.1.2
                documentGet.Timeout = 300000;
                HttpWebResponse response = requestSecureDocument(documentGet, _serverURL, username, password);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine(" Error: " + response.StatusDescription);
                    response.Close();
                }
            }
            catch (Exception ex)
            {
            }
