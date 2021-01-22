    var uQuery = from visit in visits
                 where visit.Date.Month == DateTime.Now.Month 
                     && visit.Date.Year == DateTime.Now.Year
                 group visit by visit.Date into g
                 select new
                 {
                     DayOfMonth = g.Key.Date,
                     VisitsPerDay = g.Count()
                 };
