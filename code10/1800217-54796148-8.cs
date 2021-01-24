    public class Author : Tag<string>
    {
      public Author( string name ) : base( name ) { }
      public void AddBook( Book book )
      {
        SubscribeToTag( book );
        book.SubscribeToTag( this );
      }
      public IEnumerable<Book> Books
      {
        get
        {
          return
            observables
            .Where( o => o.Tag is Book )
            .Select( o => ( Book ) o.Tag );
        }
      }
      public override void OnNext( ITag value )
      {
        switch ( value.TagType.Name )
        {
          case nameof( Book ):
            Console.WriteLine( $"{( ( Book ) value ).CurrentValue} happened to {CurrentValue}" );
            break;
        }
      }
    }
