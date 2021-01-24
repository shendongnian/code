    public static string GetTypedString(List<byte> varBytes, string varType) {
      if (null == varBytes)
        throw new ArgumentNullException(nameof(varBytes)); // or return null
      int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
      return string.Concat(varBytes
        .Select(item => item.ToString("x2")))
        .PadLeft(size * 2, '0');
    }
