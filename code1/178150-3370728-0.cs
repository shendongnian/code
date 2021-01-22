    if (txtEmailID.Text.Length > 0)
        {
            //@new list
            List<EduvisionUser> listOfAcceptedUsers = new List<EduvisionUser>()**
            
            users = UserRespository.GetUserName(txtEmailID.Text);
            bool isUserAvailable=false;
            foreach (EduvisionUser aUser in users) --->***Exception thrown in this line***
            {
                isUserAvailable = true;
                //Add user to list instead of deleting
                if(aUser.Activated)
                {
                    ListOfAcceptedUsers.Add(aUser);
                }
            }
            //check new list instead of old one
            if (ListOfAcceptedUsers.Count == 0 && isUserAvailable)
            {
                DeactivatedUserMessage();
                return;
            }
    
        }
