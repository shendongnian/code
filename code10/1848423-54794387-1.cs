    var assignmenTotal = new AssignmentUser
     {
    	 IsSupervisor = supervisor,
    	  AssignmentTotals = (from a in db.Assignments
    	 where (StartDate.HasValue) ? DbFunctions.TruncateTime(a.CreatedDate) == StartDate : a.IsArchived == false
    	 join b in db.Adjustments on a.ID equals b.AssignmentID
    		group b by new {a.ID,a.UserName,a.Status,a.CreatedDate,a.IsArchived} into g
    		 select new AssignmentTotals
    		 {
    			 ID =  g.Key.ID,
    			 UserName = g.Key.UserName,
    			 Status = g.Key.Status,
    			 ImportedDate = DbFunctions.TruncateTime(g.Key.CreatedDate),
    			 StartingLocation = (db.Adjustments.Where(x=>x.AssignmentID == g.Key.ID).OrderBy(x=>x.LocationID).Select(x=>x.LocationID).FirstOrDefault()),
    			 EndingLocation = (db.Adjustments.Where(x => x.AssignmentID == g.Key.ID).OrderByDescending(x => x.LocationID).Select(x => x.LocationID).FirstOrDefault()),
    			 TotalLocations = g.Count(x => x.LocationID != null),
    			 TotalLicensePlates = g.Count(x => x.ExpectedLicensePlateID != null),
    			 TotalAdjCompleted = g.Count(x => x.Status == "C"),
    			 IsSameUser = (currUser == g.Key.UserName ? true : false),
    			 IsArchived = g.Key.IsArchived
    		 }).ToList()
    };
