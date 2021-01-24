    foreach(UserDTO user in lstUsr)
    {
       string managerName;
       string managerEmail = GetManagerInfoByID(user.UserID, out managerName); // Returns email and send out managerName. You could use an object here instead, just showing this for demo purposes.
    
      user.ManagerName = managerName;
      user.ManagerEmail = managerEmail;
    }
