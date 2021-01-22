    public SqlDecimal? Rate
    {
        get 
        {
            if (internalRate.HasValue)
                return new SqlDecimal(internalRate.Value);
            else
                return null;
        }
    }
