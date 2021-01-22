    public SaveFile() : this(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "SaveFile.DAT") {}
    public SaveFile(string location)
    {
        this.Save(location);
    }
