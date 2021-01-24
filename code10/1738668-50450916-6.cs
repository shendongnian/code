    foreach (var lr in leavesresult) 
    {
      foreach (var leavelist in lr.LeaveList) 
      {
        if (leavelist.status == "1" && leavelist.leave_type != "3") 
        {
          var user_id = leavelist.user_id;
          int index = attendancelist.FindIndex(y => y.user_id == user_id);
          if (index != -1) 
          {
            if (leavelist.check_halfday != 1) 
              attendancelist[index].days = attendancelist[index].days + 1;
          }
          else 
          {
            double days = leavelist.check_halfday == 1 ? 0.5 : 1;
            attendancelist.Add(new AttendanceModel {user_id = user_id, days = days});
          }
        }
      }
    }
