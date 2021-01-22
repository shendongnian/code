    ObjectQuery<Visit> visits = fitent.VisitMenge;
                    var uQuery =
                        from visit in visits
                        where visit.Date.Value.Month == DateTime.Now.Month
                     && visit.Date.Value.Year == DateTime.Now.Year
                        group visit by visit.Date.Value.Day into g
                        select new
                        {
                            DayOfMonth = g.Key,
                            VisitsPerDay = g.Count()
                        };
