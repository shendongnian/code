    public static IQueryable<Payments> ToPayments(this IQueryable<Naleznosci> source)
    {
      Expression<Func<Naleznosci, Payments>> createPayments = naleznosci => new Payments
      {
        Imie = source.Dziecko.Imie,
        Nazwisko = source.Dziecko.Nazwisko,
        Nazwa= source.Miesiace.Nazwa,
        Kwota = source.Kwota,
        NazwaRodzajuOplaty = source.RodzajeOplat.NazwaRodzajuOplaty,
        NazwaTypuOplaty = source.RodzajeOplat.TypyOplat.NazwaTypuOplaty,
        DataRozliczenia = source.DataRozliczenia,
        TerminPlatnosci = source.TerminPlatnosci,
      };
      return source.Select(createPayments);
    }
