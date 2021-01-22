    using System.Net.NetworkInformation;
    int previousbytessend = 0;
    int previousbytesreceived = 0;
    int downloadspeed;
    int uploadspeed;
    IPv4InterfaceStatistics interfaceStats;
    private void timer1_Tick(object sender, EventArgs e)
        {
            
            //Must Initialize it each second to update values;
            interfaceStats = NetworkInterface.GetAllNetworkInterfaces()[0].GetIPv4Statistics();
            
            //SPEED = MAGNITUDE / TIME ; HERE, TIME = 1 second Hence :
            uploadspeed = (interfaceStats.BytesSent - previousbytessend) / 1024; //In KB/s
            downloadspeed = (interfaceStats.BytesReceived - previousbytesreceived) / 1024;
            previousbytessend= NetworkInterface.GetAllNetworkInterfaces()[0].GetIPv4Statistics().BytesSent;
            previousbytesreceived= NetworkInterface.GetAllNetworkInterfaces()[0].GetIPv4Statistics().BytesReceived;
            downloadspeedlabel.Text = Math.Round(downloadspeed, 2) + " KB/s"; //Rounding to 2 decimal places
            uploadspeedlabel.Text = Math.Round(uploadspeed, 2) + "KB/s";
        }
