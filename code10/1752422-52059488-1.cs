    myOleMenuCommand.BeforeQueryStatus += QueryCommandHandler;
    private void QueryCommandHandler(object sender)
    {
            var menuCommand = sender as Microsoft.VisualStudio.Shell.OleMenuCommand;
            if (menuCommand != null)
                menuCommand.Visible = menuCommand.Enabled = MyCommandStatus();
    }
