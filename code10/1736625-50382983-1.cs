    foreach(var computer in sessionDataQuery)
    {
        for(int count = 0; count < computer.LoginEvents.Count; count++)
        {
           var loginEvent = computer.LoginEvents[count];
           var logoutEvent = computer.LogoutEvents[count];
           sessionPairs.Add( new Sessons
           {
              DepartmentId = computer.DepartmentId,
              DepartmentName = computer.DepartmentName,
              ComputerId = computer.ComputerId,
              ComputerName = computer.ComputerName,
              LoginTime = loginEvent.EventDateTime,
              LogoutTime = logoutEvent.EventDateTime,
              UserId = loginEvent.UserId,
              UserName = loginEvent.UserName,
              Difference = logoutEvent.EventDateTime - loginEvent.EventDateTime
          }
       }
    }
