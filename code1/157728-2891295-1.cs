    void Dates(DateTime d, out DateTime b, out DateTime e)
    {
        b = new DateTime(d.Year, 1, 1);
        e = new DateTime(d.Year, 12, 31);
    }
