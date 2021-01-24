    public static readonly string ESC = "\u001B";
    ...
    ...
    ...
    //Encoding enc = Encoding.GetEncoding(1258); //vietnamese code page
    string content = "Cơm chiên với các loại gia vị truyền thống làm cho lưỡi của bạn";
    string toPrint = ESC + "t" + char.ConvertFromUtf32(94) + "\n"; 
    // First you need to convert the vietnamese string to utf-8 bytes.
    byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(content);	
    // Convert utf-8 bytes to a string.
    toPrint += System.Text.Encoding.UTF8.GetString(utf8Bytes);
