    public void ApplyToEachLineInFile(string file, Action<string> action)
    {
        using (TextReader reader = File.OpenText(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                action(line);
            }
        }
    }
