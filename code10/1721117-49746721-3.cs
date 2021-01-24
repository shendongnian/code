    public GenericFileReader(string filename)
    {
        init(ref filename);
    }
    public GenericFileReader(string filename, Encoding encoding)
    {
        init(ref filename, encoding);
    }
    
    private init(ref string filename, Encoding encoding = null)
    {
       _filename = filename;
       _encoding = encoding ?? Encoding.GetEncoding("windows-1252");
    }
