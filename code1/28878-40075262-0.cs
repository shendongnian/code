    public IQueryable<UbezpExt> UbezpFull
    {
        get
        {
            System.Linq.Expressions.Expression<
                Func<UBEZPIECZONY, UBEZP_ADRES, UBEZP_ADRES, UbezpExt>> expr =
                (u, parAdrM, parAdrZ) => new UbezpExt
                {
                    Ub = u,
                    AdrM = parAdrM,
                    AdrZ = parAdrZ,
                };
            // From here an expression builder ExprAdres is called.
            var expr2 = expr
                .ReplacePar("parAdrM", ExprAdres("M").Body)
                .ReplacePar("parAdrZ", ExprAdres("Z").Body);
            return UBEZPIECZONY.Select((Expression<Func<UBEZPIECZONY, UbezpExt>>)expr2);
        }
    }
