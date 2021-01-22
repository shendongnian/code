    public bool SubmitBugToBugTracker(string serverName,
                                            bool useProxy,
                                            string proxyHost,
                                            int proxyPort,
                                            string userName,
                                            string password,
                                            string description,
                                            string comment,
                                            int projectId)
        {
            if (!serverName.EndsWith(@"/"))
            {
                serverName += @"/";
            }
            string requestUrl = serverName + "insert_bug.aspx";
            string requestMethod = "POST";
            string requestContentType = "application/x-www-form-urlencoded";
            string requestParameters = "username=" + userName
                                      + "&password=" + password
                                      + "&short_desc=" + description
                                      + "&comment=" + comment
                                      + "&projectid=" + projectId;
            // POST parameters (postvars)
            byte[] buffer = Encoding.ASCII.GetBytes(requestParameters);
            // Initialisation
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(requestUrl);
            // Add proxy info if used.
            if (useProxy)
            {
                WebReq.Proxy = new WebProxy(proxyHost, proxyPort);
            }
            // Method is POST
            WebReq.Method = requestMethod;
            // ContentType, for the postvars.
            WebReq.ContentType = requestContentType;
            // Length of the buffer (postvars) is used as contentlength.
            WebReq.ContentLength = buffer.Length;
            // Open a stream for writing the postvars
            Stream PostData = WebReq.GetRequestStream();
            //Now we write, and afterwards, we close. Closing is always important!
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();
            // Get the response handle, we have no true response yet!
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            // Read the response (the string)
            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            string responseStream = _Answer.ReadToEnd();
            // Find out if bug submission was successfull.
            if (responseStream.StartsWith("OK:"))
            {
                MessageBox.Show("Bug submitted successfully.");
                return true;
            }
            else if (responseStream.StartsWith("ERROR:"))
            {
                MessageBox.Show("Error occured. Bug hasn't been submitted.\nError Message: " + responseStream);
                return false;
            }
            else
            {
                MessageBox.Show("Error occured. Bug hasn't been submitted.\nError Message: " + responseStream);
                return false;
            }
        }
