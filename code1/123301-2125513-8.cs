    while(reader.Read())
    {
       if (reader.IsStartElement("machine"))
       {
          Console.Write("Machine code {0}: ", reader.GetAttribute("code"));
       }
       if(reader.IsStartElement("part"))
       {
          Console.Write("Part code {0}: ", reader.GetAttribute("code"));
       }
       if (reader.NodeType == XmlNodeType.Text)
       {
          Console.WriteLine(reader.Value);
       }
    }
