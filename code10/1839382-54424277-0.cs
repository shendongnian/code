      string string_title;
    
      while (xtr.Read())
      {
        if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "name")
        {
          string_title += xtr.ReadElementString() + Environment.NewLine;
          // Console.WriteLine("Name = "+ s1);
        }
      }
      MessageBox.Show("Title: " + string_title);
