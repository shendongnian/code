      try
                {
                    string format= "autologin=1&login=true&username={0}&password={1}";
                      
                    byte[] bytes = Encoding.ASCII.GetBytes(string.Format(format, (object)HttpUtility.UrlEncode("USERNAME"), (object)HttpUtility.UrlEncode("PASSWORD")));
                    
                  HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://thephpbb3domain/ucp.php?mode=login");
                    httpWebRequest.CookieContainer = new CookieContainer(128);
                    httpWebRequest.Timeout = 10000;
                                        httpWebRequest.AllowAutoRedirect = false;
                    httpWebRequest.UserAgent = Resources.WEB_USER_AGENT;
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.ContentLength = (long)bytes.Length;
                    Stream requestStream = ((WebRequest)httpWebRequest).GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpWebResponse == null)
                    {
                        int num2 = (int)MessageBox.Show(Resources.ERR_MSG_NO_DATA);
                        return;
                    }
                    else
                    {
                        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                        streamReader.ReadToEnd().Trim();
                        streamReader.Close();
                       
                                IEnumerator enumerator2 = httpWebResponse.Cookies.GetEnumerator();
                                try
                                {
                                    while (enumerator2.MoveNext())
                                    {
                                        Cookie cookie = (Cookie)enumerator2.Current;
                                        string str = HttpUtility.UrlDecode(cookie.Value);
                                        if (cookie.Name.EndsWith("_k"))
                                        {
                                            if (cookie.Value.Length > 5)
                                            {
                                              
                                                break;
                                            }
                                        }
                                        else if (cookie.Name.EndsWith("_data") && !str.Contains("s:6:\"userid\";i:-1;") && str.Contains("s:6:\"userid\";"))
                                        {
                                           
                                          
                                        }
                                    }
                                   
                                }
                                finally
                                {
                                    IDisposable disposable = enumerator2 as IDisposable;
                                    if (disposable != null)
                                        disposable.Dispose();
                                }
                           
                       
                    }
                }
                catch (WebException ex)
                {
                    int num = (int)MessageBox.Show(ex.Message, "HTTP Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
              
