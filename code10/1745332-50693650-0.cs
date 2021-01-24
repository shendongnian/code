    string text = Encoding.ASCII
        // Decode from the 4th byte, using the 3rd byte as the length
        .GetString(bytes, index: 3, count: bytes[2])
        // Trim any trailing U+0000 characters
        .TrimEnd('\0');
    Console.WriteLine(text);
