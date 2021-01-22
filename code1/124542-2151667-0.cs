    public bool IsInRole(int roleID)
    {
        bool inRole = false;
        int i = userRoles.GetLength(0);
        for (int j = 0; j < i; j++)
        {
            int k = j;
            if (Convert.ToInt32(userRoles[k, 0]) == roleID)
            {
                inRole = true;
                break;
            }
        }
        return inRole;
    }
