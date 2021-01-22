            // From Database
            var query1 = from c in Session.CreateLinq<AcccountTransaction>()
                         join a in Session.CreateLinq<Account>()
                         on c.Account equals a
                         where c.DebitAmount >= 0
                         select new { Account = a, AccountTrans = c };
            // From Cache
            var query2 = from c in Session.GetAllCached<AcccountTransaction>()
                         join a in Session.GetAllCached<Account>()
                         on c.Account equals a
                         where c.DebitAmount >= 0
                         select new { Account = a, AccountTrans = c };
            
            var query4 = query2.Union(query1);
