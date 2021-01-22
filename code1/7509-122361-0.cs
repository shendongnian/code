    public ProductController() : this( new Foo() )
    {
      //the framework calls this
    }
    
    public ProductController(IFoo foo)
    {
      _foo = foo;
    }
