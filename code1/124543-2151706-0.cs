public bool IsInRole(int roleID)
    {
        bool inRole = false;
        try{
            int i = userRoles.GetLength(0);
            for (int j = 0; j &lt; i; j++)
            {
               if (Convert.ToInt32(userRoles[j, 0]) == roleID)
               {
                   inRole = true;
                   break;
               }
            }
        }catch(Exception up){
            throw up;
        }
        return inRole;
    }
