    static void CopyLinesRemovingConsecutiveDupes
        (TextReader reader, TextWriter writer)
    {
        string currentLine;
        string lastLine = null;
        
        while ((currentLine = reader.ReadLine()) != null)
        {
            if (currentLine != lastLine)
            {
                writer.WriteLine(currentLine);
                lastLine = currentLine;
            }
        }
    }
