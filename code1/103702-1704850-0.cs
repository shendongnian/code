    var custsLastAccess = db.CustAccesses   
                                .Where(c.AccessReason.Length>0)
                            .GroupBy(c => c.CustID, (id, custs) => new { ID=id, LastAccess=custs.OrderByDescending(c=>c.AccessDate).First().AccessDate})
                          .Select()
                            .ToList();
