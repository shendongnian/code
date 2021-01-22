            var query = from row in tableName.AsEnumerable()
                        group row by row.User into Group                        
                        select new
                        {
                            User = Group.Key,
                            SvcSum = Group.Sum(r => r.svc),
                            VssSum = Group.Sum(r => r.vss)
                        };
            foreach (var grp in query)
            {
                Console.WriteLine("{0}\t{1}\t{2}", grp.User, grp.SvcSum, grp.VssSum);
            }
