    /// <summary>
    /// Gets the specified line from a text file.
    /// </summary>
    /// <param name="lineNumber">The number of the line to return.</param>
    /// <param name="path">Identifies the text file that is to be read.</param>
    /// <returns>The specified line, is it exists, or an empty string otherwise.</returns>
    /// <exception cref="ArgumentException">The line number is negative, or the path is missing.</exception>
    /// <exception cref="System.IO.IOException">The file could not be read.</exception>
    public static string GetNthLineFromTextFile(int lineNumber, string path)
    {
        if (lineNumber < 0)
            throw new ArgumentException(string.Format("Invalid line number \"{0}\". Must be greater than zero.", lineNumber));
        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("No path was specified.");
        using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
        {
            for (int currentLineNumber = 0; currentLineNumber < lineNumber; currentLineNumber++)
            {
                if (reader.EndOfStream)
                    return string.Empty;
                reader.ReadLine();
            }
            return reader.ReadLine();
        }
    }
