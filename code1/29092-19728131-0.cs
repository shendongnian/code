    byte[] ip = address.Split('.').Select(s => Byte.Parse(s)).ToArray();
    if (BitConverter.IsLittleEndian) {
      Array.Reverse(ip);
    }
    int num = BitConverter.ToInt32(ip, 0);
