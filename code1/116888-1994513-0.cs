    byte[] bytes = new byte[length];
    fixed(byte* ptr = bytes)
    {
      bool success = Library.GetData(ptr, length);
      if (!success)
        Library.GetError();
      return Encoding.UTF8.GetString(bytes);
    }
