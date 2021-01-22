    Private bool authenticateUser()
    {
       if(authenticateWithServerA(username1, password1))
       {
         if(authenticateWithServerB(username2, password2))
           return true;
       }
         
    
       return false;
    }
