    public void Save(XmlWriter xmlWriter)
    {
        XDocument xDoc = new XDocument(new XElement("BookmarkCollection",
            Items.Select(bookmark => new XElement("Bookmark",
                new XElement("Name", bookmark.Name),
                new XElement("Link", bookmark.Link),
                new XElement("Remarks", bookmark.Remarks),
                new XElement("DateAdded", bookmark.DateAdded),
                new XElement("DateLastAccessed", bookmark.DateLastAccessed))
            )
        ));
        xDoc.Save(xmlWriter);
    }
    
    public void Save()
    {
        using (XmlWriter xmlWriter = XmlWriter.Create(m_StreamProvider.SaveFileStream(m_FilenameProvider.Filename)))
        {
            Save(xmlWriter);
        }
    }
