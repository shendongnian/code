    StreamWriter standardInput = new StreamWriter(new FileStream(inputHandle, FileAccess.Write, 0x1000, false), Console.InputEncoding, 0x1000);
    standardInput.AutoFlush = true;
    StreamReader reader = new StreamReader(new FileStream(outputHandle, FileAccess.Read, 0x1000, false), Console.OutputEncoding, true, 0x1000);
    StreamReader error = new StreamReader(new FileStream(errorHandle, FileAccess.Read, 0x1000, false), Console.OutputEncoding, true, 0x1000);
    
    while (!reader.EndOfStream)
    {
       string line = reader.ReadLine();
       if (line.Length>0) Console.WriteLine(line);
    }
