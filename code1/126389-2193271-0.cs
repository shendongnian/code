    void AddResultsTable(ref PlaceHolder p) // modifies p; adding a table
    {
        var t = new Table();
    
        AddTableHeader(ref t); // modifies t; adding a table header
    
        AddTableBody(ref t);  // modifies t; adding a table body
    
        AddTableFooter(ref t);  // modifies t; adding a table footer
    
        p.Controls.Add(t);
    }
    
    AddResultsTable(ref PlaceHolderResults);
