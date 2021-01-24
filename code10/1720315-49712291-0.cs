    // File to read/write
    var filePath = @"C:\Users\luke\Desktop\test.txt";
    // Write a file with 3 lines
    File.WriteAllLines(filePath, 
        new[] {
            "line 1",
            "line 2",
            "line 3",
        });
    // Get newline character
    byte newLine = (byte)'\n';
    // Create read buffer
    var buffer = new char[1024];
    // Keep track of amount of data read
    var read = 0;
    // Keep track of the number of lines
    var numberOfLines = 0;
    // Read the file
    using (var streamReader = new StreamReader(filePath))
    {
        do
        {
            // Read the next chunk
            read = streamReader.ReadBlock(buffer, 0, buffer.Length);
            // If no data read...
            if (read == 0)
                // We are done
                break;
            // We read some data, so go through each character... 
            for (var i = 0; i < read; i++)
                // If the character is \n
                if (buffer[i] == newLine)
                    // We found a line
                    numberOfLines++;
        }
        while (read > 0);
    }
