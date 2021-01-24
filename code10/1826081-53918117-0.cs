    var bytes = new byte[] { 0x34, 0x35, 0x35, 0x37 };
    var output = new StringBuilder();
                
    for (int i = 0; i < bytes.Length; i += 2)
    {
        output.Append(Char.ConvertFromUtf32(
           Convert.ToInt32(
               ASCIIEncoding.UTF8.GetString(
                   new byte[] { bytes[i], bytes[i + 1] }, 0, 2), 16)));
    }
