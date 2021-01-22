            string newvalue = "10";
            string presentvalue = "";
            string newstr = "";
            XmlReader xmlr = XmlReader.Create(new StringReader(str));
            
            while (xmlr.Read())
            {
                if (xmlr.NodeType == XmlNodeType.Element)
                {
                    if (xmlr.Name == "priority")
                    {
                        presentvalue = xmlr.ReadElementContentAsString();
                        newstr = str.Replace(presentvalue, newvalue);
                    }
                }
               
            }
