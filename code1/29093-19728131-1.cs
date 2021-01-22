    byte[] ip = BitConverter.GetBytes(num);
    if (BitConverter.IsLittleEndian) {
      Array.Reverse(ip);
    }
    string address = String.Join(".", ip.Select(n => n.ToString()));
