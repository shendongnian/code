                List<Visit> visits = myentitys.Visits.ToList();//Get the Visits entities you need in memory,
                                               //of course,you can filter it here
                var uQuery =
                from visit in visits
                group visit by visit.ArrivalTime.Value.Day into g
                select new
                {
                    Day = g.Key,
                    Hours = g.Average(visit => (visit.LeaveTime.Value - visit.ArrivalTime.Value).TotalMinutes)
                };
