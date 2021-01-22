     XmlDocument doc = new XmlDocument();
     doc.Load(@"e://file_2.xml");                
     XmlNodeList xlist = doc.GetElementsByTagName("documentlegal");
     int j=xlist.Count;
     for (int i = 0; i <= j; i++)
     {
          Console.WriteLine(xlist.Item(i).InnerXml);                
     }
     Console.ReadLine();
     }
