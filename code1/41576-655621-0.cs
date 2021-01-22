    protected void btnAdd_Click(object sender, EventArgs e)
    {
        bool isInsert = true;
        bool saved = SaveUserFromControlInfo(isInsert);
        ShowJsMessageBox(
            saved, 
            "Successfully added new user", 
            "An error was encountered while trying to add a new user."
            );
        if(saved) RedirectToAdmin();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool isInsert = false;
        bool saved = SaveUserFromControlInfo(isInsert);
        ShowJsMessageBox(
            saved,
            "Successfully updated selected users information.",
            "An error was encountered while trying to update the selected users information."
            );
        if (saved) RedirectToAdmin();
    }
