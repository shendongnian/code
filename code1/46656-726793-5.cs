    public /* comment */ void Foo(...)      // Comments can be everywhere
    string foo = "public void Foo(...){}";  // Don't match signatures in strings 
    private __fooClass _Foo()               // Underscores are ugly, but legal
    public // More comments                 // Signatures can span lines
        void Foo(...)
    public override void Foo(...);          // Have to recognize overrides
    void Foo();                             // Defaults to private
    void IDisposable.Dispose()              // Explicit implementation
    private void                            // Attributes
       Foo([Description("Foo")] string foo) 
    #if(DEBUG)                              // Don't forget the pre-processor
        private
    #else
        public
    #endif
        int Foo() { }
