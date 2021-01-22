    ...
    
    string isocontent = Encoding.GetEncoding("ISO-8859-1").GetString(fileContent, 0, fileContent.Length);
    byte[] isobytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(isocontent);
    byte[] ubytes = Encoding.Convert(Encoding.GetEncoding("ISO-8859-1"), Encoding.Unicode, isobytes);
    return Encoding.Unicode.GetString(ubytes, 0, ubytes.Length);
    }
