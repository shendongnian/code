    using System.Xml;
    namespace test
    {
      class myclass
      {
      public static void Main(string[] argv)
      {
        XmlTextReader reader = new XmlTextReader(argv[0]);
        XmlDocument doc = new XmlDocument(); 
        doc.Load(reader);
        reader.Close();          
        XmlNode myNode;
        XmlElement root = doc.DocumentElement;
        myNode = root.SelectSingleNode("//Category[itemName='Pen']/itemNumber");
      
        myNode.InnerText = "18";
    
        doc.Save(argv[1]);
      }
    }
    }
