    class Foo
    {
        int ID { get; set; }
        public Foo( int id )
        {
            ID = id;        
        }
    }
    void Main( )
    {
        Foo f = new Foo( 1 );
        Console.WriteLine( f.ID );  // prints "1"
        ChangeId( f );
        Console.WriteLine( f.ID );  // prints "5"
        ChangeRef( f );
        Console.WriteLine( f.ID );  // still prints "5", only changed what the copy was pointing to
    }
    static void ChangeId( Foo f )
    {
        f.ID = 5;
    }
    static void ChangeRef( Foo f )
    {
        f = new Foo( 10 );
    }
