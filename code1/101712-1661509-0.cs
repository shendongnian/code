    Decimal? total = null;
    public int SomePropertyName
    {
        get 
        { 
            if (total.HasValue) Convert.ToInt32(Decimal.Round(total.Value)); 
            return 0; // or whatever
        }
    }
