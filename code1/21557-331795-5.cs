    public void Log(string line)
    {
        using (var sw = new StreamWriter(File.Open(
            "LogFile.log", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))) {
            sw.WriteLine(line);
        }
        // Since we use the using block (which conveniently calls Dispose() for us)
        // the file well be closed at this point.
    }
