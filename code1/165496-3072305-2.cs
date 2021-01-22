            // From Database
            var query1 = from c in Session.CreateLinq<AcccountTransaction>()
                         join a in Session.CreateLinq<Account>()
                         on c.Account equals a
                         where c.DebitAmount >= 0
                         select new { Account = a, AccountTrans = c };
                         //select new { a.Name, c.DebitAmount }; 
            // From Cache
            var query2 = from c in Session.GetAllCached<AcccountTransaction>()
                         join a in Session.GetAllCached<Account>()
                         on c.Account equals a
                         where c.DebitAmount >= 0
                         select new { Account = a, AccountTrans = c };
                         //select new { a.Name, c.DebitAmount };   
            
            
            //var query3 = query2.Union(query1.Except(query2));
            var query4 = query2.Union(query1);
