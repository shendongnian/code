    public class BuildXML
    {
        static void Main( string[ ] args )
        {
            XDocument doc = new XDocument(
                //At root level
                new XElement("FolioIdentifiers",
                    new XElement("FolioId", "6798634B2F7")),
                //Also at root level
                new XElement("DocumentAuthentication",
                    new XElement("ScannedDocuments",
                        new XElement("ScannedDocument",
                            new XElement("DocumentType", "AppliationForm")))));
            doc.Save("C:\\document.xml");
        }  
    }
