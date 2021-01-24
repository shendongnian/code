        public void WriteToXML(string filename, string IP)
        {
            XDocument xmldoc = XDocument.Load(filename);
            XElement bannedIPs = xmldoc.Descendants("BannedIPs").FirstOrDefault();
            XElement newXElement = new XElement("BannedIP", IP);
            bannedIPs.Add(newXElement);
            xmldoc.Save(filename);
        }    
