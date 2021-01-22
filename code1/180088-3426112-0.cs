                string testURL = "";
                try
                {
                    // Probe for the update server. 
                    // If the update server cannot be reached, an exception will be thrown by the GetResponse method. 
    #if !DEBUG
                    testURL = ApplicationDeployment.CurrentDeployment.UpdateLocation.ToString() + "online.html"; 
    #else
                    testURL = "http://testserver/appname/online.html";
    #endif
                    HttpWebRequest webRequest = WebRequest.Create(testURL) as HttpWebRequest;
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
                    StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                    XmlDocument xmlDom = new XmlDocument();
                    xmlDom.Load(reader);
                    if (xmlDom["usdwatcherstatus"]["online"].Attributes["status"].Value.ToString() != "true")
                    {
                        MessageBox.Show(xmlDom["usdwatcherstatus"]["online"].Attributes["message"].Value.ToString());
                        this.Close();
                        return;
                    }
                }
                catch (WebException ex)
                {
                    // handle the exception 
                    MessageBox.Show("I either count not get to the website " + testURL + ", or this application has been taken offline.  Please try again later, or contact the help desk."); 
                }
