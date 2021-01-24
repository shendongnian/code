    public static IQueryable<Book> WherePublishedBetween(this IQueryable<Book> books,
        Year? start,
        Year? end)
    {
        if (start.HasValue)
        {
            if (end.HasValue)
                return books.Where(book => start.Value <= book.Year && book.Year <= end.Value);
            else
                return books.Where(book => start.Value <= book.Year);
        }
        else
        {   // no start value
            if (end.HasValue)
                return books.Where(book => book.Year <= end.Value);
            else
                return books;
        }
    }
