    if (RegKey3.GetValue("AutoConfigURL") == null)
    {
        VPNButton.Text = "ON";
         ConnectionLabel.Text = "Disconnected";
    }
    else
    {
        VPNButton.Text = "OFF";
        ConnectionLabel.Text = "Connected";
    }
