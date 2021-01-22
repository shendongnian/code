    IList<Folder> children;
    public ReadOnlyCollection<Folder> Children
    {
        get 
        { 
            return new List<Folder>(this.children).AsReadOnly(); 
        }
    }
