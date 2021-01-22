    var path = "c:/test.txt";
    
    File.WriteAllText(path, "a\nb\r\nc");
    
    using (var stream = File.OpenRead(path))
    using (var reader = new StreamReader(stream, Encoding.ASCII))
    {
        var lineBuilder = new StringBuilder();
        string line;
        char currentChar;
        int nextChar;
        while (!reader.EndOfStream)
        {
            currentChar = (char)reader.Read();
            nextChar = reader.Peek();
    
            if (!(currentChar == '\r' && nextChar == '\n'))
            {
                lineBuilder.Append(currentChar);
            }
    
            if((currentChar == '\r' && nextChar == '\n') || nextChar == -1)
            {
                line = lineBuilder.ToString();
                Console.WriteLine(line);
    
                lineBuilder = new StringBuilder();
    
                reader.Read();
            }
        }
    }
