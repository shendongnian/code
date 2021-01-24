    public interface IBookRepository
    {
       Book GetByISBN(string isbn);
       Add(Book book)
       Delete(Book book)
    }
    
    public class BookRepository: IBookRepository
    {
      private ISqlManager _sqlManager;
    
      public BookRepository(ISqlManager sqlManager)
      {
        _sqlManager = sqlManager;
      }
    
      public Book GetByISBN(string isbn)
      {
        var rows = _sqlManager.GetRows("BooksDb", "exec uspGetBookByISBN", CreateStringParam(isbn));
    
        // convert rows into book object(s)
    
       return books.FirstOrDefault();
    
      }
    
    }
