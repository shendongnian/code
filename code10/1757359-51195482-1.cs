    Envelope data;
    var xml = File.ReadAllText(@"C:\test.xml");
    
     using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
     {
          XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
          data = (Envelope)serializer.Deserialize(stream);
     }
    
     //Access the parameters here via an index.
     var val = data.Body.AddTwoStr.InputParameters[0].Value;
