    public void Login_click(object sender, EventArgs r)
    {
        //You code here
    
        User user = GetUserByUsername(txtUsername.Text);
    
        bool isPasswordMatched = VerifyPassword(txtpassword.Text, user.Hash, user.Salt);
    
        if (isPasswordMatched)
        {
            //Login Successfull
        }
        else
        {
            //Login Failed
        }
    
        //Your code here
    }
