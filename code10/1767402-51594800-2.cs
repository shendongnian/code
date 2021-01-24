    var passAllocations = db.PassAllocations.Include(p => p.PassRule)
    .Where(p => p.CompanyID == company.CompanyID);
    var pendingApprovals=db.PassLinkings
                           .Where(p => p.status="Pending")
                           .GroupBy(x=>x.PassAllocationID)
                           .Select(x=>new
                                      {
                                       PassAllocationID=x.Key.PassAllocationID,
                                       PendingForApprovalCount=x.Count()
                                      });
    var desiredResult=(from a in passAllocations
                      join b in pendingApprovals
                      on a.PassAllocationID equals b.PassAllocationID
                      select new {a,b})
                      .Select(x=>new PassAllocation
                                 {
                                  PassAllocationID=x.a.PassAllocationID,
                                  PendingForApprovalCount=x.PendingForApprovalCount
                                 }).ToList();
