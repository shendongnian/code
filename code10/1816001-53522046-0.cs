    public void SaveXmlDocToFile(XmlDocument xmlDoc,
                                 string outputFileName,
                                 bool formatXmlFile = false)
    {
       var settings = new XmlWriterSettings();
       if (formatXmlFile)
       {
          settings.Indent = true;
       }
       else
       {
          settings.Indent = false;
          settings.NewLineChars = String.Empty;
       }
       using (var writer = XmlWriter.Create(outputFileName, settings))
          xmlDoc.Save(writer);
    }
