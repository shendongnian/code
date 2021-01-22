    while(reader.Read())
    {
       if (reader.Name.Equals("machine") && (reader.NodeType == XmlNodeType.Element))
       {
          Console.Write("Machine code {0}: ", reader.GetAttribute("code"));
       }
       if(reader.Name.Equals("part") && (reader.NodeType == XmlNodeType.Element))
       {
          Console.Write("Part code {0}: ", reader.GetAttribute("code"));
       }
       if (reader.NodeType == XmlNodeType.Text)
       {
          Console.WriteLine(reader.Value);
       }
    }
