      string xml = @"
        <parent>
          <child>
            <nested />
          </child>
          <child>
            <other>
            </other>
          </child>
        </parent>
        ";
      XmlReader rdr = XmlReader.Create(new System.IO.StringReader(xml));
      while (rdr.Read())
      {
        if (rdr.NodeType == XmlNodeType.Element)
        {
          Console.WriteLine(rdr.LocalName);
        }
      }
