    IEnumerable<byte> bytes = BitConverter.GetBytes(first);
    bytes = bytes.Concat(BitConverter.GetBytes(second));
    bytes = bytes.Concat(BitConverter.GetBytes(third));
    // ... so on; you can chain the calls too
    return bytes.ToArray();
