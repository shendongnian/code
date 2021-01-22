    public static void CopyFileRemovingStrayNewlines(string sourcePath, string destinationPath, string linePrefix)
    {
        string[] lines = File.ReadAllLines(sourcePath);
        bool firstLine = true;
        using (StreamWriter writer = new StreamWriter(destinationPath, false))
        {
            foreach (string line in lines)
            {
                if (line.StartsWith(linePrefix))
                {
                    if (!firstLine)
                        writer.WriteLine();
                    else
                        firstLine = false;
                    writer.Write(line);
                }
                else
                {
                    writer.Write(" ");
                    writer.Write(line);
                }
            }
        }
    } 
