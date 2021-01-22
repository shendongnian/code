    static void CopyFiles(string dest, params string[] sources)
    {
        using (TextWriter writer = File.CreateText(dest))
        {
            foreach (string source in sources)
            {
                string text = File.ReadAllText(source);
                writer.Write(text);
            }
        }
    }
