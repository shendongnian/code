    public Row this[string s]
    {
        get
        {
            return Rows.Where(x => x.Name == s).FirstOrDefault();
        }
    }
