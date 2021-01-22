    public DateTime StartDate
    {
        get
        {
            DateTime? dt = (DateTime?)ViewState["StartDate"];
            return dt ?? DateTime.Now;
        }
    }
