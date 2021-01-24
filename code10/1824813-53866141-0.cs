    byte[] ByteArrayContent = File.ReadAllBytes(path);
    using (MemoryStream mStream = new MemoryStream())
    {
        stream.Write(ByteArrayContent , 0, (int)ByteArrayContent .Length);
        using (SpreadsheetDocument spreadsheetDoc = SpreadsheetDocument.Open(mStream , true))
        {
           // Do some work here
        }
        File.WriteAllBytes(SaveAsPath, mStream.ToArray()); 
    }
