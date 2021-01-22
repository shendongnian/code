    public string GetNextLine()
    {
        string line = this.stream.ReadLine(); // This may cause a longer running operation, especially if it's using Disk IO/etc
        // do other work?
        return line;
    }
