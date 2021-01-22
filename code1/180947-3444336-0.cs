    var binaryStr = "01110100011001010111001101110100";
    var byteArray = Enumerable.Range(0, int.MaxValue/8)
                              .Select(i => i*8)
                              .TakeWhile(i => i < binaryStr.Length)
                              .Select(i => binaryStr.Substring(i, 8))
                              .Select(s => Convert.ToByte(s, 2))
                              .ToArray();
    File.WriteAllBytes("C:\temp\test.txt", byteArray);
