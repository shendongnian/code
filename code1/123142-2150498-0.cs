    [DataMember( Name = "foo" )]
    private string foo { get; private set; }
    public Foo Foo 
    { 
      get 
      {
        return Foo.Parse(foo);
      }
    }
?
