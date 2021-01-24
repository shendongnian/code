    public static void PollNIST()
            {
                string NISTSourceURL = "https://smstestbed.nist.gov/vds/current";  // Gives us a human friendly reference to the HTMl
                // string NistXmlUrl = // Someone on stackexchange is claiming that there is another url for the XML but viewsource says otherwise 
                //-------------------------------- Current (mostly) Working Version---------------------------------------------------------------------------------
                var NISTHttpClient = new HttpClient();
                var NISTXMLRaw = NISTHttpClient.GetStringAsync(NISTSourceURL);  // We now have all of the HTML / XML Data as a raw string
                                                                                //Console.WriteLine(MazXMLRaw.Result);                   // Prints the resulting HTML to a terminal as a debug tool    (Works)   
                XmlDocument CurNISTXML = new XmlDocument();               // Generate Blank XML Doc
                CurNISTXML.LoadXml(NISTXMLRaw.Result);                     // This (".result") passes the actual string?, should then be loaded into new XML file
    
                // Get CreationTime (WORKING!)
                XmlNodeList elementHeader = CurNISTXML.GetElementsByTagName("Header");
                XmlNode curNISTHeader = elementHeader.Item(0);
                XmlAttribute creationTime = curNISTHeader.Attributes[0];  // We now have the creationTime element          
                string CurNISTTime = creationTime.InnerText;  //      //*[@id="mtconnect content"]/ul/li[1]
    
                // Get availability (WORKING!)
                XmlNodeList nodeAvailability = CurNISTXML.GetElementsByTagName("Availability");
                XmlNode availability = nodeAvailability.Item(0); // I think this is maybe a bit of a hackish / improper way to do this?
                string curNISTStatus = availability.InnerText;
    
                //Get linear tool X Coord.
                XmlNodeList deviceStream = CurNISTXML.GetElementsByTagName("ComponentStream");
                XmlNode linearCompXStream = deviceStream.Item(4);
                string curNISTX = linearCompXStream.InnerText; //  We do not need to break down the nodes any further as the value is the only text within
    
                //Get Linear tool y Coord.            
                XmlNode linearCompYStream = deviceStream.Item(5);
                string curNISTY = linearCompYStream.InnerText; //  We do not need to break down the nodes any further as the value is the only text within
                
    
                Console.WriteLine("-------BEGIN NIST DATA PACKET-------");
                Console.WriteLine("NIST Time  : " + creationTime.InnerText);
                Console.WriteLine("NIST Status: " + curNISTStatus);    
                Console.WriteLine("NIST X Pos.: " + curNISTX);
                Console.WriteLine("NIST Y Pos.: " + curNISTY);
                Console.WriteLine("--------END NIST DATA PACKET--------");
    
                //var currentNIST = new NISTDataSet()// Create new instance ofNISTdata object
            }
