    #if !SILVERLIGHT
    public SomeClass ( ) : this (null)
    {
    }
    public SomeClass(object someParam)
    #else
    public SomeClass(object someParam = null)
    #endif
    {
        m_someParam = someParam;
    }
