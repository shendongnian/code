    // base-class
    public abstract FileType FileType {get;}
    // derived-class
    public override FileType FileType {
        get {return FileType.Excel;} // or whatever
    }
