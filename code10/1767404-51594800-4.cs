    var desiredResult=(from a in db.PassAllocations
                                   .Include(pa => pa.PassRule)
    							   .Where(pa => pa.CompanyID == company.CompanyID)
                       join b in db.PassLinkings
    				               .Where(pl => pl.status="Pending")
    							   .GroupBy(pl=>pl.PassAllocationID)
                       on a.PassAllocationID equals b.Key
                       select new {a,b})
                      .Select(x=>new PassAllocation
                                 {
                                  PassAllocationID=x.a.PassAllocationID,
    							  .
    							  .  
    							  .   <------------Other Properties
    							  .
    							  .
                                  PendingForApprovalCount=x.b.Count()
    							  }).ToList();
