    var results = data.GroupBy(x => new { x.ApprovalStatus, x.Id })
                      .Select(x => new
                             {
                                ApprovalStatus = x.Key.ApprovalStatus,
                                Id = x.Key.Id,
                                Count = x.Count()
                             });
