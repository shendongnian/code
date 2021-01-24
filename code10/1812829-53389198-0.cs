    // Let's implement a generic method: we want, say, uint not object from given list
    public static T GetTypedString<T>(List<byte> varBytes) where T: struct {
      if (null == varBytes)
        throw new ArgumentNullException(nameof(varBytes));
      int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
      byte[] data = (size >= varBytes.Count)
        ? new byte[size - varBytes.Count].Concat(varBytes).ToArray()
        : varBytes.ToArray();
      // A bit of reflection: let's find out suitable Converter method
      var mi = typeof(BitConverter).GetMethod($"To{typeof(T).Name}");
      if (null == mi)
        throw new InvalidOperationException($"Type {typeof(T).Name} can't be converted");
      else
        return (T)(mi.Invoke(null, new object[] { data, 0 })); // or data.Length - size
    }
