    public GenericFileReader(string filename) 
    {
        _filename = filename;
        _encoding = Encoding.GetEncoding("windows-1252");
    }
    public GenericFileReader(string filename, Encoding encoding)
    {
        _filename = filename;
        _encoding = encoding;
    }
