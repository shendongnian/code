    public static void Main(string[] args)
    {
        var f = new Foo<int>();        
        dynamic x = 0;
        Console.WriteLine( f.Bar( 0 ) );
        Console.WriteLine( f.Bar( x ) );
    }
