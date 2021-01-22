    var items = Enumerable.Range(0, 12);
    
    foreach(var page in items.Page(3))
    {
        // Do something with each page
        foreach(var item in page)
        {
            // Do something with the item in the current page		
        }
    }
