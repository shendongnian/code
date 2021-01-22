    protected void DNSLookup(string domain)
    {
    try
    {
    //performs the DNS lookup
    IPHostEntry he = Dns.GetHostByName(domain);
    IPAddress[] ip_addrs = he.AddressList;
    txtIPs.Text = "";
    foreach (IPAddress ip in ip_addrs)
    {
    txtIPs.Text += ip + "\n";
    }
    }
    catch (System.Exception ex)
    {
    lblStatus.Text = ex.ToString();
    }
    }
