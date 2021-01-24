            var uniquelist = (from aa in ListA
                            join ba in ListB on aa.Upn equals ba.Upn into all
                            from avail in all.DefaultIfEmpty()
                            where avail == null
                            select new UserC
                            {
                                Firstname = aa.Firstname,
                                Lastname = aa.Lastname,
                                Upn = aa.Upn,
                            }).ToList();
            uniquelist.AddRange(from ba in ListB
                              select new UserC
                              {
                                  Firstname = ba.Firstname,
                                  Lastname = ba.Lastname,
                                  Upn = ba.Upn,
                              });
