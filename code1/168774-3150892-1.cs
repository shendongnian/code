       List<JobSearchResult> jobs = db.Jobs
         .Where(JobFilterExpression)
         .Select(j => new JobSearchResult
         { 
           JobNumber = j.Id, 
           Name = j.JobName, 
           Latitude = j.LocationLatitude, 
           Longitude = j.LocationLongitude, 
           Address = j.AddressLine1, 
           Shifts = j.Shifts
             .Where(ShiftFilterExpression)
             .Select(s => new ShiftSearchResult
             {
               Id = s.Id,
               Title = s.ShiftTitle,
               StartTime = s.StartTime,
               EndTime = s.EndTime,
               Positions = s.Positions
                 .Where(PositionFilterExpression)
                 .Select(p => new PositionSearchResult
                 {
                   Id = position.Id,
                   Status = position.Status
                 })
                 .ToList() 
             })
             .ToList()
         })
         .ToList(); 
