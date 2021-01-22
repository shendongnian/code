    public int? Amount
    {
        get
        {
            int i;
            if (Int32.TryParse(Request["amount"], out i))
            {
                return i;
            }
            return null;
        }
    }
