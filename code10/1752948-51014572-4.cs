    while (true)
    {
        Console.WriteLine("1. Add a Book\n2. List all books\n3. Save and exit");
        string option = Console.ReadLine();
        if (!Int32.TryParse(option, out int optionAsInt))
        {
            Console.WriteLine("Enter an integer");
            continue;
        }
        List<Book> books = new List<Book>(); // Do optional computation here
        if (optionAsInt == 1)
            CardCatalog.AddBook(books);
        else if (optionAsInt == 2)
            CardCatalog.ListBooks(books);
        else
        {
            CardCatalog.Save(books);
            break;
        }
    }
