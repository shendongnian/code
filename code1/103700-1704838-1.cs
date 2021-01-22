    var custsLastAccess = db.CustAccesses   
                        .Where(c.AccessReason.Length>0)
                        .GroupBy(c => c.CustID)
                        .Select(grp => new {
                          grp.Key,
                          LastAccess = grp.OrderByDescending(
                                 x => x.AccessDate).FirstOrDefault()
                        }).ToList();
