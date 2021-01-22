    string location = GetLocationFromDocument();
    
    private string GetLocationFromDocument()
    {
        object[] values = CalendarDoc.GetItemValue("Location");
        if( values != null && values.Length > 0 && values[0] != null )
        {
            return values[0].ToString();
        }
        return string.Empty;
    }
