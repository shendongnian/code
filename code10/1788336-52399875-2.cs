    void PrintOutFatBooks(List<Book> books)
    {
        var lines = new List<string>();
        foreach (var book in books)
        {
            if (book.Pages > 400)
            {
                lines.Add(String.Format("Book with more than 400 pages name is: {0}"
                    +", it has: {1} pages", book.BookName, books.Pages));
            }
        }
        File.WriteAllLines(@"FatBooks.csv", lines);
    }
