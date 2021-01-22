    Encoding encoding = Encoding.UTF8;
    string s = "€";
    int byteCount = encoding.GetByteCount(s);
    Console.WriteLine(byteCount); // prints "3" on the console
    byte[] bytes = new byte[byteCount];
    encoding.GetBytes(s, 0, s.Length, bytes, 0);
    int charCount = encoding.GetCharCount(bytes);
    Console.WriteLine(charCount); // prints "1" on the console
