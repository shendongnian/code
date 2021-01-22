    class Book
    {
        Library[] libraries;
       
        void RemoveFromLibrary(Library lib)
        {
            libraries.remove(lib);
            if (IsInLibrary(lib) && lib.HasBook(this)) // prevents call-loop
                lib.RemoveBook(this);
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
            books.remove(bk);
            if (HasBook(bk) && bk.IsInLibrary(this)) // prevents call-loop
                bk.RemoveLibrary(this);
        }
        
        bool HasBook(Book bk)
        {
            return books.Contain(bk);
        }
    }
