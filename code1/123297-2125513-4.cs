    using (System.IO.StringReader sr = new System.IO.StringReader(input))
    {
       using (XmlTextReader reader = new XmlTextReader(sr))
       {
          reader.WhitespaceHandling = WhitespaceHandling.None;
          while(reader.Read())
          {
             if (reader.Name.Equals("machine") && (reader.NodeType == XmlNodeType.Element))
             {
                Console.Write("Machine code {0}: ", reader.GetAttribute("code"));
                Console.WriteLine(reader.ReadString());
             }
             if(reader.Name.Equals("part") && (reader.NodeType == XmlNodeType.Element))
             {
                Console.Write("Part code {0}: ", reader.GetAttribute("code"));
                Console.WriteLine(reader.ReadString());
             }
          }
       }
    }
