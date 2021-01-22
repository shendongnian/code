        /// <summary>
        /// use this instead of a parameritized constructor when you need support
        /// for LINQ to entities
        /// </summary>
        /// <returns></returns>
        public static Func<Naleznosci, Payments> Initializer()
        {
            return n => new Payments
            {
                 Imie = n.Dziecko.Imie,
                 Nazwisko = n.Dziecko.Nazwisko,
                 Nazwa = n.Miesiace.Nazwa,
                 Kwota = n.Kwota,
                 NazwaRodzajuOplaty = n.RodzajeOplat.NazwaRodzajuOplaty,
                 NazwaTypuOplaty = n.RodzajeOplat.TypyOplat.NazwaTypuOplaty,
                 DataRozliczenia = n.DataRozliczenia,
                 TerminPlatnosc = n.TerminPlatnosci
            };
        }
