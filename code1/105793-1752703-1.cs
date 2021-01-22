    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(twitterUrl + userID + ".xml");
                    string Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(this.login + ":" + this.password));
    
                    request.Method = "POST";
                    request.ContentType = "application/xml";
                    request.AllowWriteStreamBuffering = true;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0; GTB6; SLCC1; .NET CLR 2.0.50727;";
                    request.Headers.Add("Authorization", "Basic " + Credentials);
    
                    HttpWebResponse HttpWResp = (HttpWebResponse)request.GetResponse();
    
                    string response = HttpWResp.StatusCode.ToString();
    					HttpWResp.InitializeLifetimeService();
    					HttpWResp.Close();    
                    
    				return response;
