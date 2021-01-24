	var a = (_context.LotPen.Select(lp=> new LotPenHead 
                        { 
                           LotId= lp.LotId, 
                           PenId = lp.PenId, 
                           Head = lp.HeadCountInPen
                        })
		      .Concat(_context.LotHistory
			               .Where(lh=>lh.MovementDate > new DateTime(2017,7,27) 
                                   && !lh.IsPending && !lh.IsCancelled)
						   .Select(lh=>new LotPenHead 
                              { 
                                   LotId= lh.LotId, 
                                   PenId = lh.PenId, 
                                   Head = lh.Direction == 1 ? -lh.Head : lh.Head
                              }));
		
	var results = a.GroupBy(aa=>new {aa.LotId, aa.PenId}, aa=>aa.Head)
                   .Select(aa=>new LotPenHead
                               {
                                  LotId = aa.Key.LotId, 
                                  PenId = aa.Key.PenId, 
                                  Head=aa.Sum()
                               }).ToList();
		
