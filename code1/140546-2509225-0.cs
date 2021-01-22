    public static void CopyFileRemovingStrayNewlines(string sourcePath, string destinationPath, string linePrefix)
    {
        string[] lines = File.ReadAllLines(sourcePath);
        bool firstLine = true;
        foreach (string line in lines)
        {
            if (line.StartsWith(linePrefix))
            {
                if (!firstLine)
                    File.AppendAllText(destinationPath, Environment.NewLine);
                else
                    firstLine = false;
                File.AppendAllText(destinationPath, line);
            }
            else
            {
                File.AppendAllText(destinationPath, " ");
                File.AppendAllText(destinationPath, line);
            }
        }
    } 
