    void PrintOutFatBooks(List<Book> books)
    {
        var lines = new List<string>();
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Pages > 400)
            {
                lines.Add(String.Format("Book with more than 400 pages name is: {0}"
                    +", it has: {1} pages", books[i].BookName, books[i].Pages));
            }
        }
        File.WriteAllLines(@"FatBooks.csv", lines);
    }
