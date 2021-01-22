    [XmlIgnore()]
    public object Foo { get; set; }
    [(XmlElement("Foo")]
    [EditorVisibile(EditorVisibility.Advanced)]
    public string FooSerialized 
    { 
      get { /* code here to convert any type in Foo to string */ } 
      set { /* code to parse out of get and make an instance of the proper type*/ } 
    }
