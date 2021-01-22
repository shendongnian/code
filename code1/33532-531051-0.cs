    using (XmlTextReader reader= new XmlTextReader (stream)) {
    
    while (reader.Read()) 
    {
        switch (reader.NodeType) 
        {
            case XmlNodeType.Element: // The node is an Element.
                Console.Write("<" + reader.Name);
       Console.WriteLine(">");
                break;
      case XmlNodeType.Text: //Display the text in each element.
                Console.WriteLine (reader.Value);
                break;
      case XmlNodeType. EndElement: //Display end of element.
                Console.Write("</" + reader.Name);
       Console.WriteLine(">");
                break;
        }
    }
    
    
    }
