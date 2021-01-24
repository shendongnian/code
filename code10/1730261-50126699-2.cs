    string TextDestinaton = string.Empty;
    using (FileStream FileOrigin = new FileStream(@"[SomeSourceFile]", 
                                       FileMode.Open, FileAccess.Read, FileShare.None))
    using (StreamReader orgReader = new StreamReader(FileOrigin))
    {
        Encoding OriginalEncoding = Encoding.GetEncoding(orgReader.CurrentEncoding.CodePage);
        byte[] OriginalBytes = OriginalEncoding.GetBytes(orgReader.ReadToEnd());
        byte[] DestinationBytes = Encoding.Convert(OriginalEncoding, Encoding.UTF8, OriginalBytes, 0, OriginalBytes.Length);
        using (MemoryStream memstream = new MemoryStream(DestinationBytes, 0, DestinationBytes.Length))
        using (StreamReader destReader = new StreamReader(memstream, Encoding.UTF8))
        {
            memstream.Position = 0;
            TextDestinaton = destReader.ReadToEnd();
        };
    }
