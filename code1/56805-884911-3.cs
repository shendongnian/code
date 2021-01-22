    static void CopyFiles(string dest, params string[] sources)
    {
        using (TextWriter writer = File.CreateText(dest))
        {
            foreach (string source in sources)
            {
                using (TextReader reader = File.OpenText(source))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
