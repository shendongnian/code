     var report201FinalList = (from report201Objects in listReports201
            group report201Objects by  report201Objects.ReportDate into grouping
            orderby grouping.Key
            select new Report201
            {
                 ReportDate = grouping.Key,
                 PurchaseDec = grouping.Sum(g => g.PurchaseDesc),
                 QuasiCashDec = grouping.Sum(g => g.QuasiCashDec ),
                 RepId = string.Join(",", grouping.Select(g => g.RepId)),
                 ...etc... 
            }).ToList();
