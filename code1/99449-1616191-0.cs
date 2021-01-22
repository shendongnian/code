    static void Main(string[] args) 
    { 
        String originalString = "This string contains the unicode character Pi(π)"; 
        Byte[] bytes = Encoding.UTF32.GetBytes(originalString);
    
        StringBuilder asAscii = new StringBuilder();
        foreach (Byte b in bytes)
        { 
            if (b <= 127) 
                asAscii.Append(Convert.ToChar(b)); 
            else 
                asAscii.AppendFormat("\\u{0:x4}", b); 
        } 
        Console.WriteLine("Final string: {0}", asAscii); 
        Console.ReadKey(); 
    }
 
