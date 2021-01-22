    public bool TryParse(string text, out Nullable<DateTime> nDate)
    {
        DateTime date;
        bool isParsed = DateTime.TryParse(text, out date);
        if (isParsed)
            nDate = new Nullable<DateTime>(date);
        else
            nDate = new Nullable<DateTime>();
        return isParsed;
    }
