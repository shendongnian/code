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
