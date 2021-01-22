    private List<string> _IDList = new List<string>();
    
    ...
    
    [XmlElement(ElementName= "ID")]
            public List<string> IDList
            {
                get
                {
                    return _IDList;
                }
                set
                {
                    _IDList = value;
                }
            }
