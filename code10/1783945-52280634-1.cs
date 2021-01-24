    long currentPosition = GetCurrentPosition();
    //Open File
    FileStream stream = new FileStream(LogDatabasePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    using (StreamReader reader = new StreamReader(stream))
    {
        string line;
        // Seek to the previously read position
        stream.Seek(currentPosition, SeekOrigin.Begin);
        //Check if new lines are available
        while ((line = reader.ReadLine()) != null)
        {
            // do stuff with the line
            // ...
            Console.WriteLine(line);
            // keep track of the current character position
            currentPosition += line.Length + 2; // Add 2 for newline
        }
    }
    SaveCurrentPosition(currentPosition);
