    public class CommentRepository: ICommentRepository //Only if you have the interface
    {   
        internal DbContext _context;
        internal DbSet<Comment> dbSet;
        
        public CommentRepository(DbContext context)//I think you have something like this.
        {
            _context = context;
            dbSet = context.Set<Comment>();
        }
        (...)
        public int ReturnLast()
        {
            //Use your context or DbSet here to return the data.
            var lastComment = dbSet.ToList().Last();
            return lastComment.Id;
        }
    }
