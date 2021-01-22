    static void Main(string[] args) 
    { 
        String originalString = "This string contains the unicode character Pi(π)"; 
        Byte[] bytes = Encoding.UTF32.GetBytes(originalString);
        StringBuilder asAscii = new StringBuilder();
        for (int idx = 0; idx < bytes.Length; idx += 4)
        { 
            uint codepoint = BitConverter.ToUInt32(bytes, idx);
            if (codepoint <= 127) 
                asAscii.Append(Convert.ToChar(codepoint)); 
            else 
                asAscii.AppendFormat("\\u{0:x4}", codepoint); 
        } 
        Console.WriteLine("Final string: {0}", asAscii); 
        Console.ReadKey(); 
    }
 
