    public static string CleanFullFileName(string text)
    {
        // Directory
        string directory = Path.GetDirectoryName(text);
        string expressionDirectory = new string(Path.GetInvalidPathChars());
        Regex regexDirectory = new Regex(string.Format("[{0}]", Regex.Escape(expressionDirectory)));
        directory = regexDirectory.Replace(directory, "");
    
        // Filename
        string filename = Path.GetFileName(text);
        string expressionFilename = new string(Path.GetInvalidFileNameChars());
        Regex regexFilename = new Regex(string.Format("[{0}]", Regex.Escape(expressionFilename)));
        filename = regexFilename.Replace(filename, "");
    
        return Path.Combine(directory, filename);
    }
