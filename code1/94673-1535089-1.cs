       public bool IsInterlacedGif(Stream stream)
       {
         byte[] buffer = new byte[10];
         int read;
    
         // read header
         // TODO: check that it starts with GIF, known version, 6 bytes read 
         read = stream.Read(buffer, 0, 6); 
    
         // read logical screen descriptor
         // TODO: check that 7 bytes were read
         read = stream.Read(buffer, 0, 7);
         byte packed1 = buffer[4];
         bool hasGlobalColorTable = ((packed1 & 0x80) != 0); // extract 1st bit
    
         // skip over global color table
         if (hasGlobalColorTable)
         {
            byte x = (byte)(packed1 & 0x07); // extract 3 last bits
            int globalColorTableSize = 3 * 1 << (x + 1);
            stream.Seek(globalColorTableSize, SeekOrigin.Current);
         }
    
         // read image descriptor
         // TODO: check that 10 bytes were read
         read = stream.Read(buffer, 0, 10);
         byte packed2 = buffer[9];
         return ((packed2 & 0x40) != 0); // extract second bit
      }
