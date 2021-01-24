    string message = "Eureka"; // if I use "Eureka\0\0" it works...
    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);
    // 8 bytes
    Int64 m = BitConverter.ToInt64(
      bytes.Concat(new byte[bytes.Length < sizeof(Int64) 
        ? sizeof(Int64) - bytes.Length 
        : 0]).ToArray(), 
      0); 
                                                    
    byte[] decodeBites = BitConverter.GetBytes(m);
    string decodeMessage = System.Text.Encoding.UTF8.GetString(decodeBites).TrimEnd('\0');
    if (!decodeMessage.Equals(message)) {
      Console.WriteLine("Message mis-match!!!");
    }
