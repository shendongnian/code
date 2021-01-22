    string FormatXml(string xml)
    {
         try
         {
             XDocument doc = XDocument.Parse(xml);
             return doc.ToString();
         }
         catch (Exception)
         {
             return xml;
         }
     }
