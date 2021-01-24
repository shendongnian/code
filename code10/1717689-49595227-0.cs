    var query = from a in db.Appointments
        group a by new { a.Id, a.ApptDate} into pa
        select new { 
             ID = pa.Key.Id,  
             Date = pa.Max(x =>x.ApptDate)
           }).Select(x=>new { 
                                 x.ID,x.Date
                                }).ToList();
