    public class PostBookSqlRepo : IPostBookRepository
    {
        IDbConnectionFactory dbFactory;
    
        public PostBookSqlRepo(IDbConnectionFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
    
    //...
    
        public Book CreateBooks(Book book)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                db.Insert(book);
            }
        }
    }
