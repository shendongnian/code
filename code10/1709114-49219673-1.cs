         private void materialRaisedButton16_Click(object sender, EventArgs e)
        {
        foreach (var process in Process.GetProcessesByName("RobloxPlayerBeta"))
        {
            process.Kill();
        }
        materialRaisedButton16.Text = "Successfully killed process!";
        // sleep for 2s WITHOUT freezing GUI
        Task taketime = this.DelayTask();
        }
    
