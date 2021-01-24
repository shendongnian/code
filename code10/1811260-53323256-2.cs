    public static InArchiveFormat CheckSignature (Stream stream, out int offset, out bool isExecutable)
    {
      offset = 0;
      if (!stream.CanRead)
      {
        throw new ArgumentException ("The stream must be readable.");
      }
      if (stream.Length < SIGNATURE_SIZE)
      {
        throw new ArgumentException ("The stream is invalid.");
      }
      #region Get file signature
      var signature = new byte[SIGNATURE_SIZE];
      int bytesRequired = SIGNATURE_SIZE;
      int index = 0;
      stream.Seek (0, SeekOrigin.Begin);
      while (bytesRequired > 0)
      {
        int bytesRead = stream.Read (signature, index, bytesRequired);
        bytesRequired -= bytesRead;
        index += bytesRead;
      }
      string actualSignature = BitConverter.ToString (signature);
      #endregion
      InArchiveFormat suspectedFormat = InArchiveFormat.XZ; // any except PE and Cab
      isExecutable = false;
      foreach (string expectedSignature in Formats.InSignatureFormats.Keys)
      {
        if (actualSignature.StartsWith (expectedSignature, StringComparison.OrdinalIgnoreCase) ||
            actualSignature.Substring (6).StartsWith (expectedSignature, StringComparison.OrdinalIgnoreCase) &&
            Formats.InSignatureFormats[expectedSignature] == InArchiveFormat.Lzh)
        {
          if (Formats.InSignatureFormats[expectedSignature] == InArchiveFormat.PE)
          {
            suspectedFormat = InArchiveFormat.PE;
            isExecutable = true;
          }
          else
          {
            return Formats.InSignatureFormats[expectedSignature];
          }
        }
      }
      // Many Microsoft formats
      if (actualSignature.StartsWith ("D0-CF-11-E0-A1-B1-1A-E1", StringComparison.OrdinalIgnoreCase))
      {
        suspectedFormat = InArchiveFormat.Cab; // != InArchiveFormat.XZ
      }
      #region SpecialDetect
      try
      {
        SpecialDetect (stream, 257, InArchiveFormat.Tar);
      }
      catch (ArgumentException) { }
      if (SpecialDetect (stream, 0x8001, InArchiveFormat.Iso))
      {
        return InArchiveFormat.Iso;
      }
      if (SpecialDetect (stream, 0x8801, InArchiveFormat.Iso))
      {
        return InArchiveFormat.Iso;
      }
      if (SpecialDetect (stream, 0x9001, InArchiveFormat.Iso))
      {
        return InArchiveFormat.Iso;
      }
      if (SpecialDetect (stream, 0x9001, InArchiveFormat.Iso))
      {
        return InArchiveFormat.Iso;
      }
      if (SpecialDetect (stream, 0x400, InArchiveFormat.Hfs))
      {
        return InArchiveFormat.Hfs;
      }
      #region Last resort for tar - can mistake
      if (stream.Length >= 1024)
      {
        stream.Seek (-1024, SeekOrigin.End);
        byte[] buf = new byte[1024];
        stream.Read (buf, 0, 1024);
        bool istar = true;
        for (int i = 0; i < 1024; i++)
        {
          istar = istar && buf[i] == 0;
        }
        if (istar)
        {
          return InArchiveFormat.Tar;
        }
      }
      #endregion
      #endregion
      #region Check if it is an SFX archive or a file with an embedded archive.
      if (suspectedFormat != InArchiveFormat.XZ)
      {
        #region Get first Min(stream.Length, SFX_SCAN_LENGTH) bytes
        var scanLength = Math.Min (stream.Length, SFX_SCAN_LENGTH);
        signature = new byte[scanLength];
        bytesRequired = (int)scanLength;
        index = 0;
        stream.Seek (0, SeekOrigin.Begin);
        while (bytesRequired > 0)
        {
          int bytesRead = stream.Read (signature, index, bytesRequired);
          bytesRequired -= bytesRead;
          index += bytesRead;
        }
        actualSignature = BitConverter.ToString (signature);
        #endregion
        foreach (var format in new InArchiveFormat[]
        {
                        InArchiveFormat.Zip,
                        InArchiveFormat.SevenZip,
                        InArchiveFormat.Rar,
                        InArchiveFormat.Cab,
                        InArchiveFormat.Arj
        })
        {
          int pos = actualSignature.IndexOf (Formats.InSignatureFormatsReversed[format]);
          if (pos > -1)
          {
            offset = pos / 3;
            return format;
          }
        }
        // Nothing
        if (suspectedFormat == InArchiveFormat.PE)
        {
          return InArchiveFormat.PE;
        }
      }
      #endregion
      throw new ArgumentException ("The stream is invalid or no corresponding signature was found.");
    }
