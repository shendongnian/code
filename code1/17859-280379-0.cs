        static void AppendChildren(this XmlWriter writer, string path)
        {
            using (XmlReader reader = XmlReader.Create(path))
            {
                reader.MoveToContent();
                int targetDepth = reader.Depth + 1;
                if(reader.Read()) {
                    while (reader.Depth == targetDepth)
                    {
                        writer.WriteNode(reader, true);
                    }                
                }
            }
        }
