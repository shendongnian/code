    public Foo() {
        Bar = 4;
    }
    [DefaultValue(4), XmlAttribute("bar")]
    public int Bar {get;set;}
