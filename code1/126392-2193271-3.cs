    Table ReturnTable()
    {
        var t new Table();
    
        // AddTableHeader() returns TableHeader
        t.Columns.HeaderColumns.Add(ReturnTableHeader());
    
        // ... etc.
        return t;
    }
    
    PlaceHolder.Controls.Add(ReturnTable());
