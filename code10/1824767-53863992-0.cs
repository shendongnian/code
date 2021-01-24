    try
    {
        string ips = null;
        List<string> ipList = new List<string>();
        string[] hostList = Regex.Split(txtHost.Text, "\r\n");
        foreach (var h in hostList)
        {
            // Check DNS
            if (h.Contains(".xxxx.com"))
            {
                hostName = h;
            }
            else
            {
                string code = txtHost.Text.Substring(0, 3);
                if (code == "ABC" || code == "CDE")
                    hostName = h + ".ap.xxx.com";
                else
                    hostName = "Unknown domain name";
            }
            try
           {
            IPHostEntry host = Dns.GetHostEntry(hostName);
            IPAddress[] ipaddr = host.AddressList;
    
            // Loop through the IP Address array and add the IP address to Listbox
            foreach (IPAddress addr in ipaddr)
            {
                if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipList.Add(addr.ToString());
                }
            }
          } 
          catch (System.Net.Sockets.SocketException ex)
         {
             ipList.Add("Invalid Host");
         }
        }
        foreach (var ip in ipList)
        {
            ips += ip + Environment.NewLine;
        }
        txtIP.Text = ips;
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
