    public SaveFile() : this(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\SaveFile.DAT") {}
    public SaveFile(string location)
    {
        this.Save(location);
    }
