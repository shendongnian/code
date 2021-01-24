    string Start = "0x5C 0x21 0x5C";
    byte[] ByteMessage = Start
      .Split(' ')
      .Select(item => Convert.ToByte(item, 16)) // Parse string into corresponding byte
      .ToArray();
    // Back to Hex: "5C-21-5C"
    string HexMessage = string.Join("-", ByteMessage
      .Select(item => item.ToString("X2")));
    
