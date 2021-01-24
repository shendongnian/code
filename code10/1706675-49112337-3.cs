     var items = (from a in db.ActivityLogs
                            from v in db.Vehicles
                            where (a.PlateID1 == v.PlateID || a.PlateID2 == 
                            v.PlateID) && v.Alerted == true
                            select new ActivityLog
                            { 
                               A= a, // Pseudo code
                               V = v, // Pseudo code map to essential properties
                            }).ToArray();
    foreach (ActivityLog l in items)
