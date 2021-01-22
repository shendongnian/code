        public static string PostMultipartRequest(PostData postData, string relativeUrl, IUserCredential userCredential)
        {
            string returnXmlString = "";
            try
            {
                //Initialisatie request
                WebRequest webRequest = HttpWebRequest.Create(string.Format(Settings.Default.Api_baseurl, relativeUrl));
                //Credentials
                NetworkCredential apiCredentials = userCredential.NetworkCredentials;
                webRequest.Credentials = apiCredentials;
                webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(apiCredentials.UserName + ":" + apiCredentials.Password)));
                //Post!
                webRequest.Method = "POST";
                webRequest.ContentType = "multipart/form-data; boundary=";
                //Post
                //byte[] bytesToWrite = UTF8Encoding.UTF8.GetBytes(multipartData);
                string boundary = "";
                byte[] data = postData.Export(out boundary);
                webRequest.ContentType += boundary;
                webRequest.ContentLength = data.Length;
                using (Stream xmlStream = webRequest.GetRequestStream())
                {
                    xmlStream.Write(data, 0, data.Length);
                }
                //webRequest.ContentType = "application/x-www-form-urlencoded";
                using (WebResponse response = webRequest.GetResponse())
                {
                    // Display the status
                    // requestStatus = ((HttpWebResponse)response).StatusDescription;
                    //Plaats 'response' in stream
                    using (Stream xmlResponseStream = response.GetResponseStream())
                    {
                        //Gebruik streamreader om stream uit te lezen en om te zetten naar string
                        using (StreamReader reader = new StreamReader(xmlResponseStream))
                        {
                            returnXmlString = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException wexc)
            {
                switch (wexc.Status)
                {
                    case WebExceptionStatus.Success:
                    case WebExceptionStatus.ProtocolError:
                        log.Debug("bla", wexc);
                        break;
                    default:
                        log.Warn("bla", wexc);
                        break;
                }
            }
            catch (Exception exc)
            {
                log.Error("bla");
            }
            return returnXmlString;
        }
