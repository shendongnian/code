    private LIst<Foo> fooList; 
    
    public ReadOnlyCollection<Foo> Foo { 
        get { return fooList.AsReadOnly(); }
 
