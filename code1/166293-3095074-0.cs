    using (TextWriter writer = File.CreateText("tempFile.txt"))
    {
        CopyText(reader, writer);
    }
    static void CopyText(TextReader reader, TextWriter writer)
    {
        char[] buffer = new char[8192];
        int charsRead;
        while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
        {
            writer.Write(buffer, 0, charsRead);
        }
    }
