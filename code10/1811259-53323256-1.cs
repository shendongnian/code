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
      #endregion Get file signature
      InArchiveFormat suspectedFormat = InArchiveFormat.XZ; // any except PE and Cab
      isExecutable = false;
      InArchiveFormat enDetectedFormat = (InArchiveFormat)(-1);
      InArchiveFormat enSpecialFormat = (InArchiveFormat)(-1);
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
            enDetectedFormat = Formats.InSignatureFormats[expectedSignature];
            break;
          }
        }
      }
      // Many Microsoft formats
      if (actualSignature.StartsWith ("D0-CF-11-E0-A1-B1-1A-E1", StringComparison.OrdinalIgnoreCase))
      {
        suspectedFormat = InArchiveFormat.Cab; // != InArchiveFormat.XZ
      }
      #region SpecialDetect
      if (SpecialDetect (stream, 257, InArchiveFormat.Tar))
      {
        enSpecialFormat = InArchiveFormat.Tar;
      }
      else if (SpecialDetect (stream, 0x8001, InArchiveFormat.Iso))
      {
        enSpecialFormat = InArchiveFormat.Iso;
      }
      else if (SpecialDetect (stream, 0x8801, InArchiveFormat.Iso))
      {
        enSpecialFormat = InArchiveFormat.Iso;
      }
      else if (SpecialDetect (stream, 0x9001, InArchiveFormat.Iso))
      {
        enSpecialFormat = InArchiveFormat.Iso;
      }
      else if (SpecialDetect (stream, 0x9001, InArchiveFormat.Iso))
      {
        enSpecialFormat = InArchiveFormat.Iso;
      }
      else if (SpecialDetect (stream, 0x400, InArchiveFormat.Hfs))
      {
        enSpecialFormat = InArchiveFormat.Hfs;
      }
      #region Last resort for tar - can mistake
      bool bPossiblyTAR = false;
      if (stream.Length >= 1024)
      {
        stream.Seek (-1024, SeekOrigin.End);
        byte[] buf = new byte[1024];
        stream.Read (buf, 0, 1024);
        bPossiblyTAR = true;
        for (int i = 0; i < 1024; i++)
        {
          bPossiblyTAR = bPossiblyTAR && buf[i] == 0;
        }
      }
      // TAR header starts with the filename of the archive.
      // The filename can be anything, including the Identifiers of the various archive formats.
      // This means that a TAR can be misinterpreted as any type of archive.
      if (enSpecialFormat == InArchiveFormat.Tar
      || bPossiblyTAR)
      {
        var fs = stream as FileStream;
        if (fs != null)
        {
          string sStreamFilename = fs.Name;
          if (sStreamFilename.EndsWith (".tar", StringComparison.InvariantCultureIgnoreCase))
            enDetectedFormat = InArchiveFormat.Tar;
        }
      }
      #endregion Last resort for tar - can mistake
      if (enDetectedFormat != (InArchiveFormat)(-1))
        return enDetectedFormat;
      #endregion SpecialDetect
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
        #endregion Get first Min(stream.Length, SFX_SCAN_LENGTH) bytes
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
      #endregion Check if it is an SFX archive or a file with an embedded archive.
      throw new ArgumentException ("The stream is invalid or no corresponding signature was found.");
    }
