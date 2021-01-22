     protected void btnOk_Click(object sender, EventArgs e)
    {
        var name = txtLogin.Text;
        var pwd = txtPassword.Text;
        DataSet ds = new DataSet();
        string userName = name;
        string pwdBeforeConversion = pwd;
        //Encryption of pasword
        SHA1CryptoServiceProvider x = new SHA1CryptoServiceProvider();
        byte[] data = Encoding.ASCII.GetBytes(pwdBeforeConversion);
        data = x.ComputeHash(data);
        //pass the data to service, and get a return as dataset
        try
        {
            somelogic here
        }
        catch (Exception ex3)
        {
            if (ex3.Message == "InvalidUsernameOrPassword")
                labMsg.Text = "sorry user name and password could not be found";
            else if (ex3.Message == "EmailNotVerified")
                labMsg.Text = "please contact ta; email is not verified";
            else if (ex3.Message == "AccountDisabled")
                labMsg.Text = "please contact ta; account is not verified";
            else
                labMsg.Text = "sorry we encounterd a techncal issue, please try logging in again";
            ModalPopupExtender1.Show();
            return;
        }
    }
