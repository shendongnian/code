    public static ArrayList VerifyXML(string xmlFile, string XSDFilepath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlFile);
            xDoc.Schemas.Add("Mention your target namespace here", XSDFilepath);
            xDoc.Validate(new ValidationEventHandler(ValidationCallBack)); 
            return m_oResults;
        }
     private static void ValidationCallBack(Object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    m_oResults.Add(e);
                    break;
                case XmlSeverityType.Warning:
                    m_oResults.Add(e);
                    break;
            }
        }
