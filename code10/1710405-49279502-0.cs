    private void removeDuplicateBooks(List<Book> library)
        {
            foreach(Book b in library) {
                // put book b in a new library
                List<Book> distinctLibrary = library.FindAll(b);
                // if you find more than once the book
                if(distinctLibrary.Count > 1) {
                     // delete all copies of b and keep only one
                     library.RemoveAll(b);
                     library.Add(b);
                }
            }
        }
