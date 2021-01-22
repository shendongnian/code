    static void CopyLinesRemovingAllDupes(TextReader reader, TextWriter writer)
    {
        string currentLine;
        HashSet<string> previousLines = new HashSet<string>();
        
        while ((currentLine = reader.ReadLine()) != null)
        {
            // Add removes true if it was actually added,
            // false if it was already there
            if (previousLines.Add(currentLine))
            {
                writer.WriteLine(currentLine);
            }
        }
    }
