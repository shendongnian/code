     public static void WriteElementValue ( string sName, string element, string value)
     {
      try
      {
        var node = String.Format("//elements/element[@name='{0}']", sName);
        var doc = new XmlDocument { PreserveWhitespace = true };
        doc.Load(configurationFileName);
        var nodeObject = doc.SelectSingleNode(node);
         if (nodeObject == null)
             throw new XmlException(String.Format("{0} path does not found any matching 
             node", node));
        var elementObject = nodeObject[element];
        if (elementObject != null)
        {
           elementObject.Attributes["value"].Value = value;
        }
        doc.Save(configurationFileName);
    }
    catch (Exception ex)
    {
       throw new ExitLevelException(ex, false);
    }
