    string mac = "";
    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
    
                    if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                    {
                        if (nic.GetPhysicalAddress().ToString() != "")
                        {
                            mac = nic.GetPhysicalAddress().ToString();
                        }
                    }
                }
    MessageBox.Show(mac);
