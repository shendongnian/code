    public void btnLogin_Clicked(object sender, EventArgs e)
    {
        // Now can use linq to validate the user
        // NOTE: this is case sensitive
        if (this.CredentialList.Any(a => a.Username == txtUsername.Text && a.Password == txtPassword.Text))
        {
            // NOTE: you've only validated the user here, but aren't passing
            // or storing any detail of who the currently logged in user is
            Navigation.PushModalAsync(new HomeScreen());
        }
        else
        {
            DisplayAlert("Error", "The username or password you have entered is incorrect", "Ok");
        }
    }
