    // 1. Create a junk memory stream, pass it to Image.FromStream and 
    // get the "parameter is not valid":
    MemoryStream ms = new MemoryStream(new Byte[] {0x00, 0x01, 0x02});
    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);`
    // 2. Create a junk memory stream, pass it to Image.FromStream
    // without verification:
    MemoryStream ms = new MemoryStream(new Byte[] {0x00, 0x01, 0x02});
    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms, false, true);
