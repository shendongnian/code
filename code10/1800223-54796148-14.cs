    public class Author : Tag<string>
    {
       //--> omitted stuff... <--//
       
       public IEnumerable<Bookmark> Bookmarks => Books.SelectMany( b => b.Bookmarks );
       //--> omitted stuff... <--//
    }
