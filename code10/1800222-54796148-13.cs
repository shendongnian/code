    public class Book : Tag<string>
    {
      //--> omitted stuff... <--//
    
      public IEnumerable<Bookmark> Bookmarks
      {
        get
        {
          return
            observables
            .Where( o => o.Tag is Bookmark )
            .Select( o => ( Bookmark ) o.Tag );
        }
      }
      
      //--> omitted stuff... <--//
    }
