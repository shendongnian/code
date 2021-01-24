    var attendancelist = leavesresult
                   .SelectMany(a => a.LeaveList) // flatten the list
                   .Where(a => a.status == "1" && a.type != "3") // pick the right items 
                   .GroupBy(a => a.user_id) // group by users
                   .Select(g => new AttendanceModel(){ // project the model
                        user_id = g.Key,
                        days = g.Sum(x => x.days)
                   })
                   .ToList();
