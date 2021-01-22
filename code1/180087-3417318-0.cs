                try
                {
                    // The next four lines probe for the update server.
                    // If the update server cannot be reached, an exception will be thrown by the GetResponse method.
                    string testURL = ApplicationDeployment.CurrentDeployment.UpdateLocation.ToString();
                    HttpWebRequest webRequest = WebRequest.Create(testURL) as HttpWebRequest;
                    webRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                    HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
                    // I discard the webResponse and go on to do a programmatic update here - YMMV
                }
                catch (WebException ex)
                {
                    // handle the exception
                }
  
