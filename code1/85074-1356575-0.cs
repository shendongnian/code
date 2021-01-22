    var uQuery = from visit in visits
                 where visit.Date.Month == DateTime.Now.Month
                 group visit by visit.Date into g
                 select new
                 {
                     DayOfMonth = g.Key.Date,
                     VisitsPerDay = g.Count()
                 };
