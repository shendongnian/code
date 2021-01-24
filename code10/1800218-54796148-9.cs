    public class Book : Tag<string>
    {
      public Book( string name ) : base( name ) { }
      public void AddAuthor( Author author )
      {
        SubscribeToTag( author );
        author.SubscribeToTag( this );
      }
      public IEnumerable<Author> Authors
      {
        get
        {
          return
            observables
            .Where( o => o.Tag is Author )
            .Select( o => ( Author ) o.Tag );
        }
      }
      public override void OnNext( ITag value )
      {
        switch ( value.TagType.Name )
        {
          case nameof( Author ):
            Console.WriteLine( $"{( ( Author ) value ).CurrentValue} happened to {CurrentValue}" );
            break;
        }
      }
    }
