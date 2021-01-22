    XDocument doc = XDocument.Load("file.xml");
    foreach(var element in doc.Element("SERVER").Elements()) {
      System.Diagnostics.Debug.WriteLine("Node " + element.Name.LocalName + ":");
      foreach(var attribute in element.Attributes()) {
         System.Diagnostics.Debug.WriteLine("  " + attribute.Name.LocalName + ": " + attribute.Value);
      }
    }
