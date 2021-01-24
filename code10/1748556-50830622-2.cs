     .Select(g => 
     {
         var groupedDocuments = normalDocuments
                                    .Where(x => x.DetailId == g.Key.DetailId)
                                    .GroupBy(x => x.PersianMonth)
                                    .ToDictionary(x => x.Key, 
                                                  x => new DepositTypes(x.Sum(y=>y.Debit), x.Sum(y=>y.Credit));
         Func<int, bool, decimal> getValueFunc = (id, isDebit) 
             => groupedDocuments.TryGetValue(id, out var value) 
                    ? (isDebit ? value.Debit ?? value.Credit) 
                    : 0;
         return new AccountsAgingViewModel
         {
            DetailId = g.Key.DetailId,
            DetailCode = g.Key.DetailCode,
            DetailDescription = g.Key.DetailDescription,
            FarvardinDebit = getValueFunc(1, isDeposit: true);
            OrdibeheshtDebit = getValueFunc(2, isDeposit: true);
            // etc.
         };
    }
    private class DepositTypes
    {
        public decimal Debit { get; }
        public decimal Credit {get; }
        public DepositTypes(decimal debit, decimal credit)
        {
            Debit = debit;
            Credit = credit;
        }
    }
