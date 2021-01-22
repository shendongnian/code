    // Input
    String input = "Test1234";
    // Encoding
    String outputA = String.Empty;  
    foreach (Byte b in Encoding.ASCII.GetBytes(input))
    {
    	outputA += b.ToString("X2");
    }
    
    // Decoding
    Byte[] bytes = new Byte[outputA.Length / 2];
    for (Int32 i = 0; i < outputA.Length / 2; i++)
    {
    	bytes[i] = Convert.ToByte(outputA.Substring(2 * i, 2), 16);
    }
    String outputB = Encoding.ASCII.GetString(bytes);
    
    // Output
    Console.WriteLine(input);
    Console.WriteLine(outputA);
    Console.WriteLine(outputB);
