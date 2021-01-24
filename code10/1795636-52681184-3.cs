    public bool SetDate(Date date)
    {
        if (date.ValidateDate())
        {
            this.Date = date;
            return true;
        }
        return false;
    }
