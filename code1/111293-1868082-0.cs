    public class Image : IDisposable {
    
      Stream stream;
      BinaryReader reader;
    
      Image (Stream stream)
      {
        stream.Position = 0;
        this.stream = stream;
        this.reader = new BinaryReader (stream);
      }
    
      bool Advance (int length)
      {
        if (stream.Position + length >= stream.Length)
          return false;
    
        stream.Seek (length, SeekOrigin.Current);
        return true;
      }
    
      bool MoveTo (uint position)
      {
        if (position >= stream.Length)
          return false;
    
        stream.Position = position;
        return true;
      }
    
      void IDisposable.Dispose ()
      {
        stream.Dispose ();
      }
    
      bool IsManagedAssembly ()
      {
        bool is_pe64 = false;
    
        return PerformChecks (
          () => stream.Length > 128,
          () => reader.ReadUInt16 () == 0x5a4d, // MZ
          () => Advance (58),
          () => MoveTo (reader.ReadUInt32 ()), // lfanew
          () => reader.ReadUInt32 () == 0x00004550, // PE\0\0
          () => Advance (20),
          () => { is_pe64 = reader.ReadUInt16 () == 0x20b; return true; }, // Magic
          () => Advance (is_pe64 ? 222 : 206),
          () => reader.ReadUInt32 () != 0); // CLI header rva
      }
    
      bool PerformChecks (params Func<bool> [] checks)
      {
        foreach (var check in checks)
          if (!check ())
            return false;
    
        return true;
      }
    
      public static bool IsAssembly (string file)
      {
        using (var stream = new FileStream (file, FileMode.Open, FileAccess.Read, FileShare.Read))
          return IsAssembly (stream);
      }
    
      public static bool IsAssembly (Stream stream)
      {
        using (var image = new Image (stream))
          return image.IsManagedAssembly ();
      }
    }
