    public static Expression<Func<UBEZPIECZONY, UBEZP_ADRES>> ExprAdres(string sTyp)
    {
        return u => u.UBEZP_ADRES.Where(a => a.TYP_ADRESU == sTyp)
            .OrderByDescending(a => a.DATAOD).FirstOrDefault();
    }
