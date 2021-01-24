    bool userInside = false;
    foreach (User userPick in users)
        {        
            if (userPick.userType == userType && userPick.uniqueCode == uniqueCode)
            {
                MessageBox.Show("Cool you are in!");
                userInside=true;
                break;
            }                
        }
    if (userInside==false)
        {
            MessageBox.Show("Err, not found!");
        }
