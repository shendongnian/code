                XmlReader reader = XmlReader.Create("old.xml");
            XmlWriter writer = XmlWriter.Create("new.xml");
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Comment)
                {
                    // Do your stuff here!
                }
                writer.WriteNode(reader, true);
            }
            writer.Close();
            reader.Close();
