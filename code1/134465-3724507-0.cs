    public string Login(Uri ActionUrl, string postData)
            {
                
                gRequest = (HttpWebRequest)WebRequest.Create(formActionUrl);
                gRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-GB; rv:1.9.1.8) Gecko/20100202 Firefox/3.5.8 GTBDFff GTB7.0";
    
                gRequest.CookieContainer = new CookieContainer();
                gRequest.Method = "POST";
                gRequest.Accept = " text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8, */*";
                gRequest.KeepAlive = true;
                gRequest.ContentType = @"application/x-www-form-urlencoded";
                
    
                #region CookieManagement
                if (this.gCookies != null && this.gCookies.Count > 0)
                {
                    
                    gRequest.CookieContainer.Add(gCookies);
                }
    
                
                try
                {
                    
                    string postdata = string.Format(postData);
                    byte[] postBuffer = System.Text.Encoding.GetEncoding(1252).GetBytes(postData);
                    gRequest.ContentLength = postBuffer.Length;
                    Stream postDataStream = gRequest.GetRequestStream();
                    postDataStream.Write(postBuffer, 0, postBuffer.Length);
                    postDataStream.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }
               
    
                
                try
                {
                    gResponse = (HttpWebResponse)gRequest.GetResponse();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                   
                }
    
    
    
                //check if the status code is http 200 or http ok
              
                    if (gResponse.StatusCode == HttpStatusCode.OK)
                    {
                        //get all the cookies from the current request and add them to the response object cookies
                        
                        gResponse.Cookies = gRequest.CookieContainer.GetCookies(gRequest.RequestUri);
                        //check if response object has any cookies or not
                        if (gResponse.Cookies.Count > 0)
                        {
                            //check if this is the first request/response, if this is the response of first request gCookies
                            //will be null
                            if (this.gCookies == null)
                            {
                                gCookies = gResponse.Cookies;
                            }
                            else
                            {
                                foreach (Cookie oRespCookie in gResponse.Cookies)
                                {
                                    bool bMatch = false;
                                    foreach (Cookie oReqCookie in this.gCookies)
                                    {
                                        if (oReqCookie.Name == oRespCookie.Name)
                                        {
                                            oReqCookie.Value = oRespCookie.Name;
                                            bMatch = true;
                                            break; // 
                                        }
                                    }
                                    if (!bMatch)
                                        this.gCookies.Add(oRespCookie);
                                }
                            }
                        }
                #endregion
    
    
    
                        StreamReader reader = new StreamReader(gResponse.GetResponseStream());
                        string responseString = reader.ReadToEnd();
                        reader.Close();
                        //Console.Write("Response String:" + responseString);
                        return responseString;
                    }
                    else
                    {
                        return "Error in posting data";
                    } 
                
            }
