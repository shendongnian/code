    for( int i =0; i< users.Count; i++ ) --->***Exception thrown in this line***
     {
      EduvisionUser aUser = users[i];
      isUserAvailable = true;
      if(!aUser.Activated)
      {
        users.Remove(aUser);
        i--;
      }
     }
 
