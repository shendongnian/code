    string hex = GetCleanHex("506c 65 61736520 72 656164 20686f77 2074 6f 2061 73 6b 2e");
    byte[] bytes = GetBytesFromHex(hex);
    string text = Encoding.ASCII.GetString(bytes);
    Console.WriteLine(text);
    Console.ReadKey();
