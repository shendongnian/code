    private ICollection<Photo> photos{get; set;}
    public IEnumerable<Photo> Photos
    {
        get {return (IEnumberable<Photo>)photos;}
    }
