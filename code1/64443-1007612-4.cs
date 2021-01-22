    private void ConfigureMainMenu(DIServer server,)
    {
        MenuStrip mnMnu = PresenterView.MainMenu;
        if (mnMnu.InvokeRequired)
        {
            var param = new object[] { server}
            // Private variable
            _methodInvoker = new MethodInvoker((Action)(() => ConfigureMainMenu(params)));
            _methodInvoker.BeginInvoke(new AsyncCallback(ProcessEnded), null);
            // Call _methodInvoker.EndInvoke in ProcessEnded
        }
        else
        {
            /* do work */
        }
    }
