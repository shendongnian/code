        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!validate())
                return;
            // for admin
            if (txtUserName.Text == "a" && txtPassword.Text == "a")
            {
                this.Hide();
                Globals.Email = txtUserName.Text;
                Globals.IsAdmin = true;
                Globals.Password = txtPassword.Text;
               
                // show other form
                FrmMain frmmain = new FrmMain();
                frmmain.ShowDialog();
                // close application
                //this.Close();
            }
        }
