    private void ConfigureMainMenu(DIServer server,)
    {
        MenuStrip mnMnu = PresenterView.MainMenu;
        if (mnMnu.InvokeRequired)
        {
            mnMnu.BeginInvoke(ActionConfigureMainMenu, 
                                new object[] { server});
            var params = new object[] { server}
            // Private variable
            _methodInvoker = new MethodInvoker((Action)(() => ActionConfigureMainMenu(params)));
            _methodInvoker.BeginInvoke(new AsyncCallback(ProcessEnded), null);
            // Call _methodInvoker.EndInvoke in ProcessEnded
        }
    }
