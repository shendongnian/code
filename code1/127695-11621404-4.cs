    public void ReadXml(XmlReader reader) 
    {
        reader.ReadToFollowing(XmlNodeName);
        do
        {
            using (XmlReader rowReader = reader.ReadSubtree())
            {
                Row row = CreateRow();
                row.ReadXml(rowReader);
                Collection.Add(row);
            }
        } while (reader.ReadToNextSibling(XmlNodeName));
    } 
    
    protected virtual Row CreateRow()
    {
        return new Row();
    }
