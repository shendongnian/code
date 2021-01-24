    public class Bookmark : Tag<int>
    {
      public Bookmark( Book book, int pageNumber ) : base( pageNumber, false )
      {
        SubscribeToTag( book );
        book.SubscribeToTag( this );
      }
      public Book Book
      {
        get
        {
          return
            observables
            .Where( o => o.Tag is Book )
            .Select( o => o.Tag as Book )
            .FirstOrDefault( ); //--> could be .First( ) if you null-check book in ctor
        }
      }
    }
