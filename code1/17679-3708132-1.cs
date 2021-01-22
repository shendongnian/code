    string EndPoints = "http://203.189.91.127:7777/services/spm/spm";
    
    string New_Xml_Request_String = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><soapenv:Body><OTA_AirLowFareSearchRQ EchoToken=\"0\" SequenceNmbr=\"0\" TransactionIdentifier=\"0\" xmlns=\"http://www.opentravel.org/OTA/2003/05\"><POS xmlns=\"http://www.opentravel.org/OTA/2003/05\"><Source AgentSine=\"\" PseudoCityCode=\"NPCK\"  TerminalID=\"1\"><RequestorID ID=\"\"/></Source><YatraRequests><YatraRequest DoNotHitCache=\"true\" DoNotCache=\"false\" MidOfficeAgentID=\"\" AffiliateID=\"\" YatraRequestTypeCode=\"SMPA\"/></YatraRequests></POS><TravelerInfoSummary><AirTravelerAvail><PassengerTypeQuantity Code=\"ADT\" Quantity=\"1\"/><PassengerTypeQuantity Code=\"CHD\" Quantity=\"1\"/><PassengerTypeQuantity Code=\"INF\" Quantity=\"1\"/></AirTravelerAvail></TravelerInfoSummary> <SpecificFlightInfo><Airline Code=\"\"/></SpecificFlightInfo><OriginDestinationInformation><DepartureDateTime>" + DateTime.Now.ToString("o").Remove(19, 14) + "</DepartureDateTime><OriginLocation CodeContext=\"IATA\" LocationCode=\"DEL\">" + Source + "</OriginLocation><DestinationLocation CodeContext=\"IATA\" LocationCode=\"BOM\">" + Destincation + "</DestinationLocation></OriginDestinationInformation><TravelPreferences><CabinPref Cabin=\"Economy\"/></TravelPreferences></OTA_AirLowFareSearchRQ></soapenv:Body></soapenv:Envelope>";
    
    
     protected string HttpSOAPRequest_Test(string xmlfile, string proxy)
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.InnerXml = xmlfile.ToString();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(EndPoints);
                req.Timeout = 100000000;
                if (proxy != null)
                    req.Proxy = new WebProxy(proxy, true);
                req.Headers.Add("SOAPAction", "");
                req.ContentType = "application/soap+xml;charset=\"utf-8\"";
                req.Accept = "application/x-www-form-urlencoded"; //"application/soap+xml";
                req.Method = "POST";
                Stream stm = req.GetRequestStream();
                doc.Save(stm);
                stm.Close();
                WebResponse resp = req.GetResponse();
                stm = resp.GetResponseStream();
                StreamReader r = new StreamReader(stm);
                string myd = r.ReadToEnd();
                return myd;
            }
    
       catch (Exception se)
            {
                throw new Exception("Error Occurred in AuditAdapter.getXMLDocumentFromXMLTemplate()", se);
            }
        }
