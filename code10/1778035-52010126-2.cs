        public static void AggregateTransactions()
        {
            using (var db = new ApplicationDbContext())
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                //Get a list of users who have transactions  
                var users = db.Transactions
                   .Select(x => x.User)
                   .Distinct().ToList();
                var platforms = db.Platforms.ToDictionary(ks => ks.PlatformId);
                var Transactiontypes = db.TransactionTypes.ToDictionary(ks => ks.TransactionTypeId);
                var bag = new ConccurentBag<TransactionByDay>();
                Parallel.ForEach(users, user => 
                {
                    var _transactions = db.Transactions
                    .Where(x => x.User == user)
                    .ToList();
                    //Aggregate Platforms from all transactions for user
                    Dictionary<string, int> userPlatforms = new Dictionary<string, int>();
                    Dictionary<string, int> userTransactions = new Dictionary<string, int>();
                    foreach(var transaction in _transactions)
                    {
                       if(platforms.TryGetValue(transaction.PlatformId, out var platform))
                       {
                           if(userPlatforms.TryGetValue(platform.Name, out var tmp))
                           {
                               userPlatforms[platform.Name] = tmp + 1;
                           }
                           else
                           {
                               userPlatforms.Add(platform.Name, 1);
                           }
                       }
                       if(Transactiontypes.TryGetValue(transaction.TransactionTypeId, out var type))
                       {
                           if(userTransactions.TryGetValue(type.Name, out var tmp))
                           {
                               userTransactions[type.Name] = tmp + 1;
                           }
                           else
                           {
                               userTransactions.Add(type.Name, 1);
                           }
                       }
                    }
                    bag.Add(new TransactionByDay
                    {
                        User = user,
                        Platforms = userPlatforms,     //The dictionary list is represented as json in table
                        TransactionTypes = userTransactions     //The dictionary list is represented as json in table
                    });
                });
                db.AddRange(bag);
                db.SaveChanges();
            }
        }
