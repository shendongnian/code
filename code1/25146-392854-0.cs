    public bool IsLoggedIn { get; private set;}
    public void LoginButton_Click(object sender, EventArgs e)
    {
      IsLoggedIn = DoLogin();
      if(IsLoggedIn)
      {
        this.Close()
      }
      else
      {
        DoSomethingElse();
      }
    }
