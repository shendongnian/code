    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
    UpdateCheckInfo info = null;
    info = ad.CheckForDetailedUpdate();
    if (info.IsUpdateRequired)
    {
        ad.UpdateAsync(); // I like the update dialog
        MessageBox.Show("Application was upgraded and will now restart.");
        Environment.Exit(0);
    }
