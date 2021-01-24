    for (var i = 0; i < leavesresult.Count; i++) 
    {
      foreach (var leavelist in leavesresult[i].LeaveList) 
      {
        if (leavelist.status == "1" && leavelist.leave_type != "3") 
        {
          var user_id= leavelist.user_id;
          if (attendancelist.Any(z => z.user_id == leavelist.user_id)) 
          {
            int index = attendancelist.FindIndex(y => y.user_id == leavelist.user_id);  
            if (leavelist.check_halfday != 1) 
              attendancelist[index].days = attendancelist[index].days + 1;
          }
          else 
          {
            if (leavelist.check_halfday == 1) 
              attendancelist.Add(
                new AttendanceModel {user_id = leavelist.user_id, days = 0.5});
            else 
              attendancelist.Add(
                new AttendanceModel {user_id = leavelist.user_id, days = 1});
          }
        }
      }
    }
