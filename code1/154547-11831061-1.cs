    string osVer = System.Environment.OSVersion.Version.ToString();
    
    if (osVer.StartsWith("5")) // windows 2000, xp win2k3
    {
        MessageBox.Show("xp!");
    }
    else // windows vista and windows 7 start with 6 in the version #
    {
        MessageBox.Show("Win7!");
    }
