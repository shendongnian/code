    private static readonly Regex DateFileRegex = new Regex(".*_[0-9]{8}_[\d]{6}.*");
    
    public IEnumerable<string> EnumerateDateFiles(string path)
    {
       return Directory.EnumerateFiles(path)
				  .Where(x => this.IsValidDateFile(x));
    }
    private bool IsValidDateFile(string filename)
    {
       return DateFileRegex.IsMatch(filename);
    }
