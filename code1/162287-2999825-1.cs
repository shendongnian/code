    static HashSet<string> files = new HashSet<string>();
    static object syncRoot = new object();
    void Whatever(string filename)
    {
        bool fileFound;
        lock (syncRoot)
        {
            fileFound = files.Contains(filename);
            if (!fileFound)
            {
                files.Add(filename);
                // Code to write file here
            }
        }
        if (fileFound)
        {
            // Code to Read file here
        }
    }
