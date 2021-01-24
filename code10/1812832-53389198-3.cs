    List<byte> varBytes = new List<byte>();
    varBytes.Add(0x12);
    varBytes.Add(0x34);
    varBytes.Add(0x56);
    varBytes.Add(0x78);
    int result = GetTypedString<int>(varBytes);
    Console.Write(result.ToString("x")); 
