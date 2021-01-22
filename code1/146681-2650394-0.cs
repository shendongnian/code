            string fileLocation = "clients.xml";
            if (!File.Exists(fileLocation))
            {
                XmlTextWriter writer = new XmlTextWriter( fileLocation, null );
                writer.WriteStartElement( "Clients" );
                writer.WriteEndElement();
                writer.Close();
            }
            // Load existing clients and add new 
            XElement xml = XElement.Load(fileLocation);
                xml.Add(new XElement("User",
                new XAttribute("username", loginName),
                new XElement("DOB", dob),
                new XElement("FirstName", firstName),
                new XElement("LastName", lastName),
                new XElement("Location", location)));
            xml.Save(fileLocation);
