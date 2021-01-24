    public static bool IsValidDDS(string path)
    {
      if (path == null)
        throw new ArgumentNullException(nameof(path));
      if (!File.Exists(path)) // Check for existence.
        return false;
      uint magicNumber = 0; byte[] headerLength = new byte[sizeof(byte)];
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      {
        byte[] magic = new byte[sizeof(uint)];
        // I'm still pretty used to C and fread, so here you go :^)
        if (fs.Read(magic, 0, sizeof(uint)) != sizeof(uint))
          return false; // Not even a valid file.
        if (fs.Read(headerLength, 0, sizeof(byte)) != sizeof(byte))
          return false; // Not enough bytes, even if the first 4 bytes were checked.
        // Convert to a big endian integer.
        magicNumber = (uint)((magic[0] << 24) | (magic[1] << 16) | (magic[2] << 8) | magic[3]);
      }
      return (headerLength[0] == 0x7C) && (magicNumber == 0x44445320);
    }
