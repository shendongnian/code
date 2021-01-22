    private void Connect2Service()
    {
      ServiceReference.UserServiceClient client = new ServiceReference.UserServiceClient();
      client.GetPasswordCompleted += 
                 new EventHandler<GetPasswordCompletedEventArgs>(client_GetPasswordCompleted);
      client.GetPasswordAsync();
    }
    private void client_GetPasswordCompleted(object sender, GetPasswordCompletedEventArgs e)
    {
        // Textblock will show the output. In your case "123"
        textblock.Text = e.Result;
    }
