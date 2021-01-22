    static void CopyFiles(string dest, params string[] sources)
    {
        using (TextWriter writer = File.CreateText(dest))
        {
            // Somewhat arbitrary limit, but it won't go on the large object heap
            char[] buffer = new char[16 * 1024]; 
            foreach (string source in sources)
            {
                using (TextReader reader = File.OpenText(source))
                {
                    int charsRead;
                    while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, charsRead);
                    }
                }
            }
        }
    }
