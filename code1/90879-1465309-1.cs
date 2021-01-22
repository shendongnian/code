    class WorkerClass
    {
      public void SerializeListToFile(IList<IXmlSerializable> list, string fileName)
      {
        using (XmlWriter writer = new XmlTextWriter(fileName))
        {
          foreach (IXmlSerializable item in list)
            item.WriteXml(writer);
    
          writer.Close();
        }
      }
    }
