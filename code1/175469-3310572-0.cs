    public SomeComplexType SomeProp { get;set;}
    [DataMember(Order=1)]
    private int SomePropProxy {
        get { return SomeProp.ToInt32(); }
        set { SomeProp = SomeComplexType.FromInt32(value); }
    }
