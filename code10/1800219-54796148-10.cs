    var book = new Book( "Pride and..." );
    var author = new Author( "Jane Doe" );
    
    book.AddAuthor( author );
    
    Console.WriteLine( "\nbook's authors..." );
    foreach ( var writer in book.Authors )
    {
      Console.WriteLine( writer.Value );
    }
    
    Console.WriteLine( "\nauthor's books..." );
    foreach ( var tome in author.Books )
    {
      Console.WriteLine( tome.Value );
    }
    author.AddBook( book ); //--> maybe an error
    Console.WriteLine( "\nbook's authors..." );
    foreach ( var writer in book.Authors )
    {
      Console.WriteLine( writer.Value );
    }
    
    Console.WriteLine( "\nauthor's books..." );
    foreach ( var tome in author.Books )
    {
      Console.WriteLine( tome.Value );
    }
