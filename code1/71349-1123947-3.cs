    string FormatXml(string xml)
    {
         try
         {
             XDocument doc = XDocument.Parse(xml);
             return doc.ToString();
         }
         catch (Exception)
         {
             // Handle and throw if fatal exception here; don't just ignore them
             return xml;
         }
     }
