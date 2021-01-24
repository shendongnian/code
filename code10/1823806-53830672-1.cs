    if (RegKey3.GetValue("AutoConfigURL") != null) // Reversed the check here
    {
        VPNButton.Text = "ON";
        ConnectionLabel.Text = "Disconnected";
    }
    else
    {
        VPNButton.Text = "OFF";
        ConnectionLabel.Text = "Connected";
    }
