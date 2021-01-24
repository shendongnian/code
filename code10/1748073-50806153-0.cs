    public void btnLogin_Click(object sender, EventArgs args)
        {
            if (method.Authenticate(user.Text, pass.Text))
                FormsAuthentication.RedirectFromLoginPage(user.Text, true);
            else
            { // <-- Missing
                Panelwarning.Visible = true;
                Msg.Text = "Login failed";
                PanelLogin.Visible =false; 
            } // <-- Missing
        }
