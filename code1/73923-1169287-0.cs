    Encoding encoding = Encoding.UTF8;
    string s = "€";
    byte[] bytes = new byte[encoding.GetByteCount(s)];
    encoding.GetBytes(s, 0, s.Length, bytes, 0);
    int charCount = encoding.GetCharCount(bytes);
    Console.WriteLine(charCount); // prints "1" on the console
