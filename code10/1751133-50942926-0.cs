    DateTime appservertime = DateTime.ParseExact(
        GetLinuxServerTime(kvp.Value), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
    public string GetLinuxServerTime(string ip)
    {
        using (var client = new SshClient(ip.Trim(), UserName, Password))
        {
             client.Connect();
             SshCommand x = client.RunCommand("date +%Y%m%d%H%M%S");
             string a = x.Result.ToString();
             client.Disconnect();
             return a;
        }
    }
