        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
        long bytesReceived = 0;
        foreach (NetworkInterface inf in interfaces)
        {
            if (inf.OperationalStatus == OperationalStatus.Up &&
                inf.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                inf.NetworkInterfaceType != NetworkInterfaceType.Tunnel &&
                inf.NetworkInterfaceType != NetworkInterfaceType.Unknown && !inf.IsReceiveOnly)
            {
                bytesReceived += inf.GetIPv4Statistics().BytesReceived;
            }
        }
        if (bytesReceivedPrev == 0)
        {
            bytesReceivedPrev = bytesReceived;
        }
        long bytesUsed = bytesReceived - bytesReceivedPrev;
        double kBytesUsed = bytesUsed / 1024;
        double mBytesUsed = kBytesUsed / 1024;
        internetUsage.Add(now, mBytesUsed);
        if (internetUsage.Count > 20)
        {
            internetUsage.Remove(internetUsage.Keys.First());
        }
        bytesReceivedPrev = bytesReceived;
    }
    private void CheckInternetSpeed(DateTime now)
    {
        WebClient client = new WebClient();
        Uri URL = new Uri("http://sixhoej.net/speedtest/1024kb.txt");
        double starttime = Environment.TickCount;
        client.DownloadFile(URL, Constants.GetAppDataPath() + "\\" + now.Ticks);
        double endtime = Environment.TickCount;
        double secs = Math.Floor(endtime - starttime) / 1000;
        double secs2 = Math.Round(secs, 0);
        double kbsec = Math.Round(1024 / secs);
        double mbsec = kbsec / 100;
        internetSpeed.Add(now, mbsec);
        if (internetSpeed.Count > 20)
        {
            internetSpeed.Remove(internetSpeed.Keys.First());
        }
        client.Dispose();
        try
        {
            // delete downloaded file
            System.IO.File.Delete(Constants.GetAppDataPath() + "\\" + now.Ticks);
        }
        catch (Exception ex1)
        {
            Console.WriteLine(ex1.Message);
        }
    }
