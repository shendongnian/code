        public static void AggregateTransactions()
        {
            using (var db = new ApplicationDbContext())
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                //Get a list of users who have transactions  
                var transactionsByUser = db.Transactions
                   .GroupBy(x => x.User) //Not sure if EF Core supports this kind of grouping
                   .ToList();
                var platforms = db.Platforms.ToDictionary(ks => ks.PlatformId);
                var Transactiontypes = db.TransactionTypes.ToDictionary(ks => ks.TransactionTypeId);
                var bag = new ConccurentBag<TransactionByDay>();
                Parallel.ForEach(transactionsByUser, transaction => 
                {
                    //Aggregate Platforms from all transactions for user
                    Dictionary<string, int> platforms = new Dictionary<string, int>(); //This can be converted to a ConccurentDictionary
                    //This can be converted to Parallel.ForEach
                    foreach (var item in _transactions.Select(x => platforms[x.PlatformId]).GroupBy(x => x.Name).ToList())
                    {
                        platforms.Add(item.Key, item.Count());
                    };
                   //Aggregate TransactionTypes from all transactions for user
                   Dictionary<string, int> transactionTypes = new Dictionary<string, int>(); //This can be converted to a ConccurentDictionary
                    //This can be converted to Parallel.ForEach
                    foreach (var item in _transactions.Select(x => Transactiontypes[c.TransactionTypeId]).GroupBy(x => x.Name).ToList())
                    {
                        transactionTypes.Add(item.Key, item.Count());
                    };
                    bag.Add(new TransactionByDay
                    {
                        User = transaction.Key,
                        Platforms = platforms,     //The dictionary list is represented as json in table
                        TransactionTypes = transactionTypes     //The dictionary list is represented as json in table
                    });
                });
                //Before calling this we may need to check the status of the Parallel ForEach, or just convert it back to regular foreach loop if you see no benefit.
                db.AddRange(bag);
                db.SaveChanges();
            }
        }
