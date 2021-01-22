    public bool TryParse(string text, ref Nullable<DateTime> nDate)
    {
        DateTime date;
        bool isParsed = DateTime.TryParse(text, out date);
        if(isParsed)
            nDate = date;
        return isParsed;
    }
