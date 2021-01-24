    string Start = "0x5C 0x21 0x5C";
    byte[] ByteMessage = Start
      .Split(' ')                               // Split string into items
      .Select(item => Convert.ToByte(item, 16)) // Parse items into corresponding bytes
      .ToArray();                               // Materialize into array
    // Back to Hex (let's have a look on what we are going to send): "5C-21-5C"
    string HexMessage = string.Join("-", ByteMessage
      .Select(item => item.ToString("X2")));
    
