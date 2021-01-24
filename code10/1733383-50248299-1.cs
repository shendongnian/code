    if (username.Text == "" && password.Text == "")
    {
        MessageBox.Show("Please Enter Username and Password");
    }
    else if (!File.Exists(username.Text + ".txt"))
    {
        err.SetError(username, "Username not exist"); //sets the error
        //MessageBox.Show("Please Enter Your Username");
    } else {
      ....
    }
