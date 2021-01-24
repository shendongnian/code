    string[] lines = new WebClient().DownloadString("Checker.php")
                     .Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    foreach (var line in lines)
    {
        string[] config = line.Split('=');
        if (config[0] == "AdminPanelEnabled")
        {
            AdminPanel.Enabled = bool.Parse(config[1]);
        }
        else if (config[0] == "UserIPPanelEnabled")
        {
            UserIPPanel.Enabled = bool.Parse(config[1]);
        }
        else if (config[0] == "GuestPanelEnabled")
        {
            GuestPanel.Enabled = bool.Parse(config[1]);
        }
    }
