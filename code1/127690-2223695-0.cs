        public void ReadXml<T>(XmlReader reader) where T : IRow
        {
            reader.ReadToFollowing(XmlNodeName);
            do
            {
                using (XmlReader rowReader = reader.ReadSubtree())
                {
                    var row = default(T);
                    row.ReadXml(rowReader);
                    Collection.Add(row);
                }
            } while (reader.ReadToNextSibling(XmlNodeName));
        } 
