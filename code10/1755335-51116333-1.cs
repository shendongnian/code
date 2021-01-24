    class Program
    {
        static void Main(string[] args)
        {
            Librarian obj = new Librarian();
            obj.AddToBooklist();
             
            //this needs to be moved here, instead to be in the add to book list method.
            Novel objNovel = new Novel();
            objNovel.Print();
            Console.ReadKey(); 
        }
    }
    class Book
    {
        public string author;
        public String title;
    }
    class Librarian
    {
        public List<Book> booklist = new List<Book>();
        public void AddToBooklist()
        {
            //create a book to add into booklist
            Novel newBook = new Novel();
            newBook.author = "Henri";
            newBook.title = "Papillon";
            booklist.Add(newBook);
            foreach (var item in booklist)
            {
                Console.WriteLine(item.author + " " + item.title);// Prints fine
            }
            Console.WriteLine(booklist[0].author + " " + booklist[0].title);// prints fine too
        }                                                             // create an object to get into Novel class 
    }
    class Novel : Book
    {
        public void Print()
        {
            Librarian objLib = new Librarian();// create object to get into Librarian class
            objLib.AddToBooklist();//invoke the method that will add the book to the list
            foreach (var item in objLib.booklist)
            {
                Console.WriteLine(item.author + " " + item.title);// prints nothing
            }
            Console.WriteLine(objLib.booklist[0].author); // causes program to crash
        }
    }
