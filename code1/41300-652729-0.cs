    class MailUtil
    {
        private CredentialCache creds = new CredentialCache();
        public MailUtil()
        {
            // set up webdav connection to exchange
            this.creds = new CredentialCache();
            this.creds.Add(new Uri("http://mail.domain.com/Exchange/me@domain.com/Inbox/"), "Basic", new NetworkCredential("myUserName", "myPassword", "WINDOWSDOMAIN"));
        }
        /// <summary>
        /// Gets all unread emails in a user's Inbox
        /// </summary>
        /// <returns>A list of unread mail messages</returns>
        public List<model.Mail> GetUnreadMail()
        {
            List<model.Mail> unreadMail = new List<model.Mail>();
            string reqStr =
                @"<?xml version=""1.0""?>
                    <g:searchrequest xmlns:g=""DAV:"">
                        <g:sql>
                            SELECT
                                ""urn:schemas:mailheader:from"", ""urn:schemas:httpmail:textdescription""
                            FROM
                                ""http://mail.domain.com/Exchange/me@domain.com/Inbox/"" 
                            WHERE 
                                ""urn:schemas:httpmail:read"" = FALSE 
                                AND ""urn:schemas:httpmail:subject"" = 'tbintg' 
                                AND ""DAV:contentclass"" = 'urn:content-classes:message' 
                            </g:sql>
                    </g:searchrequest>";
            byte[] reqBytes = Encoding.UTF8.GetBytes(reqStr);
            // set up web request
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://mail.domain.com/Exchange/me@domain.com/Inbox/");
            request.Credentials = this.creds;
            request.Method = "SEARCH";
            request.ContentLength = reqBytes.Length;
            request.ContentType = "text/xml";
            request.Timeout = 300000;
            using (Stream requestStream = request.GetRequestStream())
            {
                try
                {
                    requestStream.Write(reqBytes, 0, reqBytes.Length);
                }
                catch
                {
                }
                finally
                {
                    requestStream.Close();
                }
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                try
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(responseStream);
                    // set up namespaces
                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
                    nsmgr.AddNamespace("a", "DAV:");
                    nsmgr.AddNamespace("b", "urn:uuid:c2f41010-65b3-11d1-a29f-00aa00c14882/");
                    nsmgr.AddNamespace("c", "xml:");
                    nsmgr.AddNamespace("d", "urn:schemas:mailheader:");
                    nsmgr.AddNamespace("e", "urn:schemas:httpmail:");
                    // Load each response (each mail item) into an object
                    XmlNodeList responseNodes = document.GetElementsByTagName("a:response");
                    foreach (XmlNode responseNode in responseNodes)
                    {
                        // get the <propstat> node that contains valid HTTP responses
                        XmlNode uriNode = responseNode.SelectSingleNode("child::a:href", nsmgr);
                        XmlNode propstatNode = responseNode.SelectSingleNode("descendant::a:propstat[a:status='HTTP/1.1 200 OK']", nsmgr);
                        if (propstatNode != null)
                        {
                            // read properties of this response, and load into a data object
                            XmlNode fromNode = propstatNode.SelectSingleNode("descendant::d:from", nsmgr);
                            XmlNode descNode = propstatNode.SelectSingleNode("descendant::e:textdescription", nsmgr);
                            // make new data object
                            model.Mail mail = new model.Mail();
                            if (uriNode != null)
                                mail.Uri = uriNode.InnerText;
                            if (fromNode != null)
                                mail.From = fromNode.InnerText;
                            if (descNode != null)
                                mail.Body = descNode.InnerText;
                            unreadMail.Add(mail);
                        }
                    }
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                }
                finally
                {
                    responseStream.Close();
                }
            }
            return unreadMail;
        }
    }
