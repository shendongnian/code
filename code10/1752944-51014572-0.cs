            string option = "1"; // Make sure we enter the while loop
            while (option == "1" || option == "2")
            {
                Console.WriteLine("1. Add a Book\n2. List all books\n3. Save and exit");
                option = Console.ReadLine();
                List<Book> books = new List<Book>(); // Do optional computation here
                switch (option)
                {
                    case "1":
                        CardCatalog.AddBook(books);
                        break;
                    case "2":
                        CardCatalog.ListBooks(books);
                        break;
                    default:
                        CardCatalog.Save(books);
                        break;
                }
            }
