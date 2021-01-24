    static string calendarURI = "https://caldav.icloud.com/";
        static string username = "abc@icloud.com";
        static string password = "xxxx-xxxx-xxxx-xxxx";
        //static string content = "<?xml version=\"1.0\" encoding=\"utf-8\"?><propfind xlmns=\"DAV:\"><allprop/></propfind>";
        static string content = "<propfind xmlns='DAV:'><prop><current-user-principal/></prop></propfind>";
    public async static void GetCalendars()
        {
            try
            {
                ResponseStream = ExectueMethod(username, password, calendarURI, "PROPFIND", null, content, "application/x-www-form-urlencoded","0");
                XmlDocument = new XmlDocument();
                XmlDocument.Load(ResponseStream);
                string xmlInner = XmlDocument.InnerXml;
                XmlDocument innerXmlDocument = new XmlDocument();
                innerXmlDocument.LoadXml(xmlInner);
                XmlNode statusCheck = innerXmlDocument.GetElementsByTagName("status")[0];
                if (statusCheck != null)
                {
                    string status = statusCheck.InnerText.Trim();
                    if (status == "HTTP/1.1 200 OK")
                    {
                        XmlNode tag = innerXmlDocument.GetElementsByTagName("current-user-principal")[0];
                        if (tag != null)
                        {
                            XmlNode taghref = tag.ChildNodes[0];
                            if (taghref != null)
                            {
                                string href = taghref.InnerText.Trim();
                                string baseUrl = "https://caldav.icloud.com" + href;
                                Console.WriteLine("BASSE URL :" + baseUrl);
                                content = "<propfind xmlns='DAV:' xmlns:cd='urn:ietf:params:xml:ns:caldav'><prop><cd:calendar-home-set/></prop></propfind>";
                                ResponseStream = ExectueMethod(username, password, baseUrl, "PROPFIND", null, content, "application/x-www-form-urlencoded","0");
                                XmlDocument = new XmlDocument();
                                XmlDocument.Load(ResponseStream);
                                xmlInner = XmlDocument.InnerXml;
                                innerXmlDocument = new XmlDocument();
                                innerXmlDocument.LoadXml(xmlInner);
                                tag = innerXmlDocument.GetElementsByTagName("calendar-home-set")[0];
                                if (tag != null)
                                {
                                    taghref = tag.ChildNodes[0];
                                    if (taghref != null)
                                    {
                                        string calURL = taghref.InnerText.Trim();
                                        Console.WriteLine("CALENDER URL :" + calURL);
                                        content = "<propfind xmlns='DAV:'><prop><displayname/><getctag />calendar-data</prop></propfind>";
                                        ResponseStream = ExectueMethod(username, password, calURL, "PROPFIND", null, content, "application/x-www-form-urlencoded","1");
                                        XmlDocument = new XmlDocument();
                                        XmlDocument.Load(ResponseStream);
                                        xmlInner = XmlDocument.InnerXml;
                                        innerXmlDocument = new XmlDocument();
                                        innerXmlDocument.LoadXml(xmlInner);
                                        int xx = 0;
                                        
                                        foreach (XmlNode row in innerXmlDocument.GetElementsByTagName("response"))
                                        {
                                            if (xx > 0)
                                            {
                                                string calhrefUrlfinal = row.InnerXml.Remove(row.InnerXml.IndexOf("</href>"));
                                                calhrefUrlfinal = calhrefUrlfinal.Replace("<href xmlns=\"DAV:\">", "");
                                                string Calname = row.InnerXml.Remove(row.InnerXml.IndexOf("</displayname>"));
                                                Calname = Calname.Remove(0, Calname.IndexOf("<displayname>")).Replace("<displayname>", "").Trim();
                                                string statusx = row.InnerXml.Remove(row.InnerXml.IndexOf("</status>"));
                                                statusx = statusx.Remove(0, statusx.IndexOf("<status>")).Replace("<status>", "").Trim();
                                                if (statusx == "HTTP/1.1 200 OK")
                                                {
                                                    Console.Write("THIS IS VALID CAL!");
                                                    // ADD THIS CAL TO LIST TO SHOW!
                                                    content = "<propfind xmlns='DAV:'><prop><calendar-data/><getctag /></prop></propfind>";
                                                    ResponseStream = ExectueMethod(username, password, calhrefUrlfinal, "PROPFIND", null, content, "application/x-www-form-urlencoded", "1");
                                                    XmlDocument = new XmlDocument();
                                                    XmlDocument.Load(ResponseStream);
                                                    xmlInner = XmlDocument.InnerXml;
                                                    XmlDocument icsSoc = new XmlDocument();
                                                    icsSoc.LoadXml(xmlInner);
                                                    foreach (XmlNode ics in icsSoc.GetElementsByTagName("href"))
                                                    {
                                                        string t = ics.InnerText.Trim();
                                                        if (t.Contains(".ics"))
                                                        {
                                                            DownloadICS(t, Calname + ".ics");
                                                            break;
                                                        }
                                                    }
                                                }
                                                
                                            }
                                            xx = xx + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
           private static void DownloadICS(string pathUri, string fileNames)
        {
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential(username, password);
            Byte[] data = request.DownloadData(pathUri);
            var str = System.Text.Encoding.Default.GetString(data);
            string path = "icloudCalenders\\" + fileNames.Substring(fileNames.LastIndexOf(" / ") + 1);
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }
    private static Stream ExectueMethod(string username, string password, string caldevURI, string methodName, WebHeaderCollection headers, string content, string contentType,string depth)
        {
            HttpWebRequest httpGetRequest = (HttpWebRequest)WebRequest.Create(caldevURI);
            httpGetRequest.Credentials = new NetworkCredential(username, password);
            httpGetRequest.PreAuthenticate = true;
            httpGetRequest.Method = methodName;
            httpGetRequest.Headers.Add("Depth", depth);
            httpGetRequest.Headers.Add("Authorization", username);
            //httpGetRequest.UserAgent = "DAVKit/3.0.6 (661); CalendarStore/3.0.8 (860); iCal/3.0.8 (1287); Mac OS X/10.5.8 (9L31a)";
            httpGetRequest.UserAgent = "curl/7.37.0";
            if (!string.IsNullOrWhiteSpace(contentType))
            {
                httpGetRequest.ContentType = contentType;
            }
            using (var streamWriter = new StreamWriter(httpGetRequest.GetRequestStream()))
            {
                string data = content;
                streamWriter.Write(data);
            }
            //Stream requestStream = httpGetRequest.GetRequestStream();
            //requestStream.Write(optionsArray, 0, optionsArray.Length);
            //requestStream.Close();
            HttpWebResponse httpGetResponse = (HttpWebResponse)httpGetRequest.GetResponse();
            Stream responseStream = httpGetResponse.GetResponseStream();
            return responseStream;
        }
