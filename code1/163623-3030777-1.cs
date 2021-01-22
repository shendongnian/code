    class CommonBooks
    {
        static void Main()
        {
            List<Person> persons = new List<Person>()
            {
                new Person(1, "Jane"), new Person(2, "Joan"), new Person(3, "Jim"), new Person(4, "John"), new Person(5, "Jill")
            };
    
            List<Book> books = new List<Book>()
            {
                new Book(1), new Book(2), new Book(3), new Book(4), new Book(5)
            };
            List<PersonBook> personBooks = new List<PersonBook>()
            {
                new PersonBook(1,1), new PersonBook(1,2), new PersonBook(1,3), new PersonBook(1,4), new PersonBook(1,5), 
                new PersonBook(2,2), new PersonBook(2,3), new PersonBook(2,5), 
                new PersonBook(3,2), new PersonBook(3,4), new PersonBook(3,5), 
                new PersonBook(4,1), new PersonBook(4,4),
                new PersonBook(5,1), new PersonBook(5,3), new PersonBook(5,5)
            };
    
            int basePersonId = 4; // person to match likeness
    
            var query = from personBook in personBooks
                        where personBook.PersonId != basePersonId
                        join bookbase in personBooks
                        on personBook.BookId equals bookbase.BookId
                        where bookbase.PersonId == basePersonId
                        join person in persons
                        on personBook.PersonId equals person.Id
                        group person by person into bookgroup
                        select new
                        {
                            Person = bookgroup.Key,
                            BooksInCommon = bookgroup.Count()
                        };
    
            foreach (var item in query)
            {
                Console.WriteLine("{0}\t{1}", item.Person.Name, item.BooksInCommon);
            }
    
            Console.Read();
        }
    }
    
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person(int id, string name) { Id = id; Name = name; }
    }
    
    class Book
    {
        public int Id { get; set; }
        public Book(int id) { Id = id; }
    }
    
    class PersonBook
    {
        public int PersonId { get; set; }
        public int BookId { get; set; }
        public PersonBook(int personId, int bookId) { PersonId = personId; BookId = bookId; }
    }
