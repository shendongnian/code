    private void cloneCustomer(int n)
        {
            var tableQuotes = from d in globalVars.Db.Table<dbQuotes>()
                              where d.CustomerName == globalVars.Customer
                              select d;
            globalVars.Db.RunInTransaction(() => {
              for (int i = 1; i <= n; i++) {
                foreach (var quote in tableQuotes){              
                    quote.CustomerName = "Default customer " + i;
                    globalVars.Db.Insert(quote);
                 }
               }
           });
    }
