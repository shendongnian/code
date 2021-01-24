    List<byte> varBytes = new List<byte>();
    varBytes.Add(0x12);
    varBytes.Add(0x34);
    varBytes.Add(0x56);
    varBytes.Add(0x78);
    string result1 = GetTypedString<int>(varBytes);
    string result2 = GetTypedString<long>(varBytes);
    Console.WriteLine(result1); 
    Console.WriteLine(result2); 
