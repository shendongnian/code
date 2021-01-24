            var uniquelist = (from aa in a
                            join ba in b on aa.Upn equals ba.Upn into all
                            from avail in all.DefaultIfEmpty()
                            where avail == null
                            select new UserC
                            {
                                Firstname = aa.Firstname,
                                Lastname = aa.Lastname,
                                Upn = aa.Upn,
                            }).ToList();
            uniquelist.AddRange(from ba in b
                              select new UserC
                              {
                                  Firstname = ba.Firstname,
                                  Lastname = ba.Lastname,
                                  Upn = ba.Upn,
                              });
