    public void ReadXml<T>(XmlReader reader) where T : IRow, new()
    {
        reader.ReadToFollowing(XmlNodeName);
        do
        {
            using (XmlReader rowReader = reader.ReadSubtree())
            {
                var row = new T();
                row.ReadXml(rowReader);
                Collection.Add(row);
            }
        } while (reader.ReadToNextSibling(XmlNodeName));
    } 
