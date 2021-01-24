            if (username.Text == "" && password.Text == "")
            {
                MessageBox.Show("Please Enter Username and Password");
                return;
            }
    
            if (!File.Exists(username.Text + ".txt"))
            {
                err.SetError(username, "Username not exist"); //sets the error
                //MessageBox.Show("Please Enter Your Username");
            }
            else
            {
               err.SetError(username, ""); //clears the error
                err.SetError(password, "");
                TextReader tr = new StreamReader(username.Text + ".txt");
                string pass = tr.ReadLine();
                if (pass == password.Text)
                {
                    app.Show();
                    this.Hide();
                }
                else
                {
                    err.SetError(password, "Password Incorrect");
                   // MessageBox.Show("Please Enter Your Password");
                }
