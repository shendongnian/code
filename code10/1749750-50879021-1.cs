    public static bool SaveContacts(XmlDocument application)
        {
            // COMMENTED CODE IS YOU OLD STUFF
            //XDocument xmessage = XDocument.Parse(application.OuterXml);
            //XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";//Envelop namespace s
            //XNamespace xsd = "http://www.w3.org/2001/XMLSchema";//Envelop namespace s
            //XNamespace soap = "http://schemas.xmlsoap.org/soap/envelope/";//Envelop namespace s
            //XNamespace d = "http://tempuri.org/";//bookHotelResponse namespace
            //XNamespace externalsystemreference = "0743A61C-B3F8-4B51-AF1E-FBE76172D34C";//d namespace
            //XNamespace externalid = "d77ddae7-ad19-4c4a-b3bf-1e83df82e40f";//d namespace
            XmlNodeList nodeList = application.GetElementsByTagName("scheme");
            string hisStuff;
            foreach (XmlNode n in nodeList)
            {
                hisStuff = n.InnerText;
            }
            //foreach (var itm in xmessage.Descendants(xsi + "Body")
            //    .Descendants(externalsystemreference + "grantapplication").Descendants(externalid + "grantapplication"))
            //{
            //    string ss = itm.Element(d + "scheme").Value;
            //}
            return true;
        }
