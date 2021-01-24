    using (var sr = new StreamReader(filePath))
    {
        long position = 0;
        var buffer = new char[513];
        while (sr.Peek() >= 0)
        {
            sr.Read(buffer, 0, buffer.Length);
            if (buffer[511] == '\r' && buffer[512] == '\n')
            {
                position += 513;
                Console.WriteLine("CRLF");
            }
            else if (buffer[511] == '\r' || buffer[511] == '\n')
            {
                position += 512;
                sr.BaseStream.Seek(position, SeekOrigin.Begin);
                sr.DiscardBufferedData();
                Console.WriteLine("CR or LF");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
                break;
            }
        }
    }
