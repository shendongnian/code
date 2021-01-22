    public void IsbnEntered()
    {
        var isbn = view.Isbn;
        if (isbnService.NumberIsValue(isbn))
        {
            var details = isbnService.RetrieveDetailsForIsbn(isbn);
            
            if (details != null)
            {
                view.Display(details);
                view.EnableSaveButton();
            }
            else
            {
                view.DisplayError("ISBN could not be found");
            }
        }
        else
        {
            view.DisplayError("Invalid ISBN");
        }
    }
