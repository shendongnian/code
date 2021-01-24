    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + s);
                    try
                    {
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        if (response.StatusCode.ToString() == "OK")
                        {
                            returnValue = s;
                        response.Close();
                        break;
                        }else
                        {
                            returnValue = "";
                        response.Close();
                    }
                        
                    }
                    catch (Exception ex) {
                        returnValue = "";
                    
                };
