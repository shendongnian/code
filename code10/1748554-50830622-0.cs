     .Select(g => 
     {
         var groupedDocuments = normalDocuments.Where(x => x.DetailId == g.Key.DetailId)
                                               .GroupBy(x=>x.PersianMonth)
                                               .ToDictionary(x=>x.Key, x=>x.Sum(y=>y.Debit)) ;
         Func<int, int> getValueFunc = id 
             => groupedDocuments.TryGetValue(id, out var value) 
                    ? value 
                    : 0;
         return new AccountsAgingViewModel
         {
            DetailId = g.Key.DetailId,
            DetailCode = g.Key.DetailCode,
            DetailDescription = g.Key.DetailDescription,
            FarvardinDebit = getValueFunc(1);
            OrdibeheshtDebit = getValueFunc(2);
            // etc.
         };
    }
