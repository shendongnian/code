    class Currency
    {
         public static reaonly IEnumerable<Currency> Currencies = new List<Currency>
         {
             new Currency { Name = "USD", CurrencySign = "$" },
             new Currency { Name = "EUR", CurrencySign = "€" }
         }
    
         public string Name {get; private set;}
    
         public string CurrencySign {get; private set;}
         
         public override ToString() { return Name; }
    }
