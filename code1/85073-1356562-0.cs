    ObjectQuery<Visit> visits = fitent.VisitMenge;
    var uQuery = from visit in visits
                 group visit by visit.Date.Day into g
                 select new
                 {
                     DayOfMonth = g.Key,
                     VisitsPerDay = g.Count()
                 };
