    // check the user is entitled to use the system at all 
    if (usrData.IsValidUser(sCurrentUserName, ref sErrMsg))
    {
        // if the user is admin then let them spoof and edit their own data 
        if (usrData.UserIsAdmin(sCurrentUserName, ref sErrMsg))
        {
            chkSpoof.Visible = true;
            grdvwUserDataFromDB.Visible = true;
        }
    }
    else
    {
        // redirect them away
        Response.Redirect("UserNotRegistered.aspx");
        return;
        
    }
