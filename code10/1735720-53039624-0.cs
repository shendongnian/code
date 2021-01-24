    private void DetectComplete(object sender, DetectCompleteEventArgs e)
    {
        // Parse the command line string before any planning.
        this.ParseCommandLine();
        this.root.InstallState = InstallationState.Waiting;
        if (LaunchAction.Uninstall == WixBA.Model.Command.Action)
        {
            WixBA.Model.Engine.Log(LogLevel.Verbose, "Invoking automatic plan for uninstall");
            WixBA.Plan(LaunchAction.Uninstall);
        }
