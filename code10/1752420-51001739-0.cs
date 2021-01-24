        private void OnQueryStatus(object sender)
        {
                Microsoft.VisualStudio.Shell.OleMenuCommand menuCommand =
                    sender as Microsoft.VisualStudio.Shell.OleMenuCommand;
                if (menuCommand != null)
                    menuCommand.Visible = menuCommand.Enabled = MyCommandStatus();
        }
