    class Book
    {
        Library[] libraries;
       
        void RemoveFromLibrary(Library lib)
        {
            if (IsInLibrary(lib) && lib.HasBook(this)) // prevents call-loop
                lib.RemoveBook(this);
            libraries.remove(lib);
        }
        
        bool IsInLibrary(Library lib)
        {
            return libraries.Contain(lib);
        }
    }
    
    
    class Library
    {
        Book[] books;
       
        void RemoveBook(Book bk)
        {
            if (HasBook(bk) && bk.IsInLibrary(this)) // prevents call-loop
                books.RemoveLibrary(this);
            books.remove(bk);
        }
        
        bool HasBook(Book bk)
        {
            return books.Contain(bk);
        }
    }
