    if (!reader.IsEmptyElement)
    {
        reader.ReadStartElement("CAR");
        // Read the content
        _tDate = DateTime.Parse(reader.ReadContentAsString());
        reader.ReadEndElement();
    }
    else
        reader.Skip();
