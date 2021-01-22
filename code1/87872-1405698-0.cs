      public void Merge(List<string> xmlFiles, string outputFileName)
      {
         DataSet complete = new DataSet();
         foreach (string xmlFile in xmlFiles)
         {
            XmlTextReader reader = new XmlTextReader(xmlFile);
            DataSet current = new DataSet();
            current.ReadXml(reader);
            complete.Merge(current);
         }
         complete.WriteXml(outputFileName);
      }
