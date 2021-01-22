    private void changeXMLVal(string element, string value)
    {
        try
        {
            string fileLoc = "PATH_TO_XML_FILE";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLoc);
            XmlNode node = doc.SelectSingleNode("/MyXmlType/" + element);
            if (node != null)
            {
                node.InnerText = value;
            }
            else
            {
                XmlNode root = doc.DocumentElement;
                XmlElement elem;
                elem = doc.CreateElement(element);
                elem.InnerText = value;
                root.AppendChild(elem);
            }
            doc.Save(fileLoc);
            doc = null;
        }
        catch (Exception)
        {
            /*
             * Possible Exceptions:
             *  System.ArgumentException
             *  System.ArgumentNullException
             *  System.InvalidOperationException
             *  System.IO.DirectoryNotFoundException
             *  System.IO.FileNotFoundException
             *  System.IO.IOException
             *  System.IO.PathTooLongException
             *  System.NotSupportedException
             *  System.Security.SecurityException
             *  System.UnauthorizedAccessException
             *  System.UriFormatException
             *  System.Xml.XmlException
             *  System.Xml.XPath.XPathException
            */
        }
    }
