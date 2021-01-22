    // 1. Read the content of the file
    string[] readText = File.ReadAllLines(path);
    // 2. Empty the file
    File.WriteAllText(path, String.Empty);
    // 3. Fill up again, but without the deleted line
    using (StreamWriter writer = new StreamWriter(path))
    {
        foreach (string s in readText)
        {
            if (!s.Equals(lineToBeRemoved))
            {
                writer.WriteLine(s);
            }
        }
    }
