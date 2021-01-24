    using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
    {
        if (unc.NetUseWithCredentials(uncpath, user, domain, password))
        {
            //Access your file here...
        }
        else
        {
            // The connection has failed. Use the LastError to get the system error code
            MessageBox.Show("Failed to connect to " + tbUNCPath.Text + 
                            "\r\nLastError = " + unc.LastError.ToString(),
                            "Failed to connect",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
