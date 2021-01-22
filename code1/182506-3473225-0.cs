    System.IO.BinaryWriter bw = new System.IO.BinaryWriter(System.IO.File.Open(@"C:\file.ext", System.IO.FileMode.Create));
        
    int x = 65535;
        
    byte[] bytes = new byte[2];
    bytes[0] = (byte)(x >> 8);
    bytes[1] = (byte)(x);
    
    bw.Write(bytes);
