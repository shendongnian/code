    ObjectQuery<Visit> visits = myentitys.Visits;
    var uQuery = from visit in visits
                 group visit by visit.ArrivalTime.Value.Day into g
                 select new
                 {
                     Day = g.Key,
                     Hours = g.Average(visit => System.Data.Objects.SqlClient.SqlFunctions.DateDiff("m", visit.LeaveTime.Value, visit.ArrivalTime.Value))
                 };
