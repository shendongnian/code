    BusinessLogic businessLogic = new BusinessLogic();
    
    private void btnLogin_Click(object sender, EventArgs e)
            {
                if (businessLogic.Authorize(txtUserName.Text, txtPassword.Text)
                {
                     MessageBox.Show("Login Successfully!");
                     this.Hide();
                     main.showMeForm4(this);
                }
                else
                {
                     txtPassword.Focus();
                    MessageBox.Show("Username or Password Is Incorrect");
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }
            }
