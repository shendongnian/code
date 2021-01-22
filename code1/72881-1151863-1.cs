    void Main( )
    {
        MyClass test = new MyClass( );
        MyClass.SomeProperty = false;
        Foo( test );
        Console.WriteLine( test.SomeProperty );  // prints "False"
    }
