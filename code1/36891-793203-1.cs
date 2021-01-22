    var bookList = new BookList
    {
        Books = { new Book { Title = "Once in a lifetime", Authors = "A.Nonymous", ISBN = "135468", ISBN13 = "1231518" } }
    };
    var serializer = new XmlSerializer(typeof(BookList));
    using (var writer = new StreamWriter("YourFileNameHere")) 
    {
        serializer.Serialize(writer, bookList); 
    }
