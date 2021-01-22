    public static boolean ByteArrayEquals(byte[] a, byte[] b) {
      if (a.Length!= a.Length)
        return false;
      for (int i = 0; i < a.Length; i++)
      {
          if (a[i] != b[i])
            return false;
      }
      return true;
    }
