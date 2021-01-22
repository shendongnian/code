    [Extension()]
    public SelectList ToSelectList(System.Enum source)
    {
        var values = from Enum e in Enum.GetValues(source.GetType)
                    select new { ID = e, Name = e.ToString() };
        return new SelectList(values, "Id", "Name");    
    }
