    string TextDestinaton = string.Empty;
    using (FileStream FileOrigin = new FileStream(@"[SomeSourceFile]", 
                                       FileMode.Open, FileAccess.Read, FileShare.None))
    using (StreamReader orgReader = new StreamReader(FileOrigin))
    {
        Encoding OriginalEncoding = Encoding.GetEncoding(orgReader.CurrentEncoding.CodePage);
        byte[] OriginalBytes = OriginalEncoding.GetBytes(orgReader.ReadToEnd());
        byte[] DestinatonBytes = Encoding.Convert(OriginalEncoding, Encoding.UTF8, OriginalBytes, 0, OriginalBytes.Length);
        using (MemoryStream memstream = new MemoryStream(DestinatonBytes, 0, DestinatonBytes.Length))
        using (StreamReader destReader = new StreamReader(memstream, Encoding.UTF8))
        {
            memstream.Position = 0;
            TextDestinaton = destReader.ReadToEnd();
        };
    }
