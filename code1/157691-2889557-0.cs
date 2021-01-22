    // Create an instance of StreamReader to read from a file.
    // The using statement also closes the StreamReader.
    using (StreamReader sr = new StreamReader("TestFile.txt")) 
    {
        string line;
        bool processLine = false;
        // Read lines from the file until the end of the file is reached.
        while ((line = sr.ReadLine()) != null) 
        {
            if (processLine)
            {
                // Your processing here
            }
            // Check to see if we need to process the next lines
            if (line.StartsWith("Feat. Type,"))
            {
                processLine = true;
            }
        }
