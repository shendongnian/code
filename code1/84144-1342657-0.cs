    void Foo()
    {
      dynamic preDisplay = cb.PreDisplay;
      DoSomethingWith( preDisplay );  // runtime dispatch using dynamic runtime (DLR)
    }
    
    void DoSomethingWith( RedPreDisplay r ) { ... }  // code specific to RefPreDisplay
    void DoSomethingWith( GreenPreDisplay g ) { ... } // code specific to GreenPreDisplay
    void DoSomethingWIth( IPreDisplay o ) { ... }  // catch-all
