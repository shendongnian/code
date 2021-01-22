    using(Stream sIn = new FileStream(inPath))
    {
      using(Stream sOut = new FileStream(outPath))
      {
        int b = sIn.ReadByte();
        while(b >= 0)
        {
          b = (byte)b+1; // or some other value
          sOut.WriteByte((byte)b);
          b = sIn.ReadByte();
        }
        sOut.Close();
      }
      sIn.Close();
    }
