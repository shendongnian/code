    internal void FixBytes()
    {
        //Convert the bytes from VB6 style BSTR to standard byte[].
              
        char[] destinationAsChars = 
        System.Text.Encoding.Unicode.GetString(File).ToCharArray();
    
        byte[] asciiBytes =  Encoding.Default.GetBytes(destinationAsChars);
        byte[] newFile = new byte[asciiBytes.Length];
        Buffer.BlockCopy(asciiBytes,0, newFile, 0, asciiBytes.Length);
        File = newFile;
    }
