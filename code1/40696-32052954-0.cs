      public void ReadXmlFile()
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data"); // Finds the location of App_Data on server.
            XmlTextReader reader = new XmlTextReader(System.IO.Path.Combine(path, "XMLFile7.xml")); //Combines the location of App_Data and the file name
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        break;
                    case XmlNodeType.Text:
                        columnNames.Add(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }
        }
