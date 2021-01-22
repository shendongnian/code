    public SaveFile(string location)
    {
        // Constructor logic here
        //TODO: Implement save event.
        this.Save(location);
    }
    public SaveFile(): this(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\SaveFile.DAT")
    {
    }
