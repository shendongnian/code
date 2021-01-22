    private void ShellButton_Click(object sender, EventArgs e)
    {
        if (CurrentSelectedSite == null)
        {
            AlertSelectSite();
            return;
        }
        SystemViewPanel panel = ShowPanel<SystemViewPanel>(this, CurrentSelectedSite.Systems);
        /*
        I decided that this since this panel is used quickly, I'd rather 
        keep the flow of what's happening in the same place. The line
        above shows the panel, a double click later, and I'm back to doing
        what the ShellButton does. */
        panel.SystemsListbox.DoubleClick += delegate(object s, EventArgs eArgs)
        {
            ListBox p = (ListBox)s;
            SecurusSystem system = (SecurusSystem)p.SelectedItem;
            if (system != null)
            {
                Process shell = new Process();
                shell.StartInfo = new ProcessStartInfo("cmd.exe",
                String.Format(@"/K psexec.exe \\{0} -u {1} -p {2} cmd.exe", system.IpAddress, CurrentSelectedSite.RemoteAccess.UserName, CurrentSelectedSite.RemoteAccess.DecryptedPassword));
                shell.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                shell.StartInfo.UseShellExecute = true;
                shell.Start();
            }
            this.Controls.Remove(p.Parent);
            p.Parent.Dispose();
            this.SearchPanel.BringToFront();
        };
    }
