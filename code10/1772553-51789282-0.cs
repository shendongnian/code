    //This is how the original call gets initiated from UI
    private async void uiLogin_Click(object sender, EventArgs e)
    {
       Agent resp = await Client.Login(new Credentials(uiUsername.Text, uiPassword.Text));
       uiAuthToken.Text = Client.getAuthToken();
    }
    
    public async Task<Agent> Login(Credentials loginInfo)
    {
        var result = await LoginAsync(loginInfo);
        return result.Content;
    }
