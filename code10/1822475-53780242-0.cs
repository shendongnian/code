    private void RemoveBookFromInventory(int bookID)
    {
        foreach(Books book in listOfBooks)
        {
             if(book.bookID == bookID)
             {
                listOfBooks.Remove(book); //wont work
             }
        }
    
        for(int i=0;i<listOfBooks.Count();i++)
        {
            if (listOfBooks[i].bookID == bookID)
                listOfBooks.Remove(listOfBooks[i]);
        }
    }
