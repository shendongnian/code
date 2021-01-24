     new AssignTodoVM
     {
    
         CreatedDate = System.DateTime.Now,    
         UserId = s.UserId,
         userName = s.UserName,
         TeamId = q.AppTeamID,
         TaskId = -1, // this is very likely wrong!
         TaskName = "",
         TOdoPresetTeamID = -1,
     }
