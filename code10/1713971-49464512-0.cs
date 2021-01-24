    using (var reader = XmlReader.Create("Operator.xml"))
    {
        string sOperator = "";
        string sPassword = "";
        string sGroup = "";
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Operator")
            {
                reader.Read(); // move to Text node
                sOperator = reader.Value;
            }
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Password")
            {
                reader.Read(); // move to Text node
                sPassword = reader.Value;
            }
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Group")
            {
                reader.Read(); // move to Text node
                sGroup = reader.Value;
            }
        }
        return Tuple.Create(sOperator, sPassword, sGroup);
    }
