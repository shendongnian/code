     var doc = new XDocument();
                    var root = new XElement("Sites"); // Sites node
                    var siteServers = new XElement("SiteServers"); // SiteServers node
                    List<XElement> siteServerList = new List<XElement>(); // list of SiteServer nodes
                    //I am not sure, where you are getting ID, siteID etc., so I will pretend like you are adding them by foreach, like from list, or something.
                    foreach( var site in sites)
                    {
                        XElement siteServer = new XElement("SiteServer");
                        siteServer.Add(new XElement("ID", site.ID));
                        siteServer.Add(new XElement("SiteID", site.siteID));
                        // etc...
        
                        siteServerList.Add(siteServer);
        
                    }
                    foreach(var siteServer in siteServerList)
                    {
                        siteServers.Add(siteServer);
                    }
                    root.Add(siteServers);
                    doc.Add(root);
                    doc.Save("YourPath");
