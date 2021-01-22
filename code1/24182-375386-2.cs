    private myCollection _MyCollection; 
    public myCollection MyCollection { 
        get { return _MyCollection.AsReadOnly(); } 
        private set { _MyCollection = value; } 
    } 
