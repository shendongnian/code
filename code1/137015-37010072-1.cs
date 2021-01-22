    public static FxRate CanCross(FxRate r1, FxRate r2)
    {
        FxRate nr = null;
                
        if (r1.Ccy1.Equals(r2.Ccy1) && r1.Ccy2.Equals(r2.Ccy2) ||
            r1.Ccy1.Equals(r2.Ccy2) && r1.Ccy2.Equals(r2.Ccy1)
            ) return null; // Same with same.
    
        if (r1.Ccy1.Equals(r2.Ccy1))
        { // a/b / a/c = c/b
            nr = new FxRate()
            {
                Ccy1 = r2.Ccy2,
                Ccy2 = r1.Ccy2,
                Rate = r1.Rate / r2.Rate
            };
        }
        else if (r1.Ccy1.Equals(r2.Ccy2))
        {
            // a/b * c/a = c/b
            nr = new FxRate()
            {
                Ccy1 = r2.Ccy1,
                Ccy2 = r1.Ccy2,
                Rate = r2.Rate * r1.Rate
            };
        }
        else if (r1.Ccy2.Equals(r2.Ccy2))
        {
            // a/c / b/c = a/b
            nr = new FxRate()
            {
                Ccy1 = r1.Ccy1,
                Ccy2 = r2.Ccy1,
                Rate = r1.Rate / r2.Rate
            };
        }
        else if (r1.Ccy2.Equals(r2.Ccy1))
        {
            // a/c * c/b = a/b
            nr = new FxRate()
            {
                Ccy1 = r1.Ccy1,
                Ccy2 = r2.Ccy2,
                Rate = r1.Rate * r2.Rate
            };
        }
        return nr;
    }
