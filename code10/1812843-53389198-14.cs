    // Let's implement a generic method: we want, say, uint not object from given list
    public static T GetTypedString<T>(List<byte> varBytes) where T: struct {
      if (null == varBytes)
        throw new ArgumentNullException(nameof(varBytes));
      // sizeof alternative 
      int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
      // if data is too short we should pad it; either from left or from right:
      // {0, ..., 0} + data or data + {0, ..., 0}
      // to choose the way, let's have a look at endiness 
      byte[] data = (size >= varBytes.Count)
        ? BitConverter.IsLittleEndian 
           ? varBytes.Concat(new byte[size - varBytes.Count]).ToArray()
           : new byte[size - varBytes.Count].Concat(varBytes).ToArray()
        : varBytes.ToArray();
      // A bit of reflection: let's find out suitable Converter method
      var mi = typeof(BitConverter).GetMethod($"To{typeof(T).Name}");
      if (null == mi)
        throw new InvalidOperationException($"Type {typeof(T).Name} can't be converted");
      else
        return (T)(mi.Invoke(null, new object[] { data, 0 })); // or data.Length - size
    }
