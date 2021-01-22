            string userID = "lsdfjk";
            UserInfo userInfo = null;
            Hashtable htMembers = new Hashtable();
            if (htMembers.ContainsKey(userID))
            {
                userInfo = (UserInfo)htMembers[userID];
            }
            else
            {
                //It's a new member
                userInfo = new UserInfo(userID);
            }
