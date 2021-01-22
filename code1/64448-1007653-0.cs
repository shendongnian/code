    private void ConfigureMainMenu(DIServer server,)
    {
        MenuStrip mnMnu = PresenterView.MainMenu;
        if (mnMnu.InvokeRequired)
        {
            mnMnu.BeginInvoke(new Action<DIServer>(ConfigureMainMenu), 
                                new object[] { server});
        }
        else
        {
            // Do actual work here
        }
    }
