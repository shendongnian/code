     private class Book   
       {   
           public string Author { get; set; }   
           public string Name { get; set; }   
           public DateTime Published { get; set; }   
       }   
          
       //Create and fill a list of books   
       private List<Book> Books = new List<Book> {   
            new Book { Author="Mcconnell",Name="Code Complete", Published=new DateTime(1993,05,14) },  
            new Book { Author="Sussman",Name="SICP (2nd)", Published=new DateTime(1996,06,01) },  
            new Book { Author="Hunt",Name="Pragmatic Programmer", Published=new DateTime(1999,10,30) },  
        };  
          
        // returns a new collection of books containing just SICP and Pragmatic Programmer.  
        private IEnumerable<Book> BooksPublishedAfter1995()  
        {  
            return Books.FindAll(Book => Book.Published > new DateTime(1995, 12, 31));
        }  
