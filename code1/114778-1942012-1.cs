      var s= new System.Xml.Serialization.XmlSerializer(typeof(TypeToSerialize));
      var ns= new System.Xml.Serialization.XmlSerializerNamespaces();
      ns.Add( "", "");
      System.IO.StreamWriter writer= System.IO.File.CreateText(filePath);
      s.Serialize(writer, objectToSerialize, ns);
      writer.Close();
