    MemoryStream stream = new MemoryStream();
    Document doc = new Document(PageSize.A4);
    RtfWriter2.GetInstance(doc, stream);
    // (...) document content
    doc.Close();
    string rtfText = ASCIIEncoding.ASCII.GetString(stream.GetBuffer());
    stream.Close();
    Clipboard.SetText(rtfText, TextDataFormat.Rtf);
