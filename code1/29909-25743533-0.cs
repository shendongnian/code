    string s = "Hello World";
    
    // String to Byte[]
    byte[] byte1 = System.Text.Encoding.Default.GetBytes(s);
    // OR
    
    byte[] byte2 = System.Text.ASCIIEncoding.Default.GetBytes(s);
    
    // Byte[] to string
    string str = System.Text.Encoding.UTF8.GetString(byte1);
