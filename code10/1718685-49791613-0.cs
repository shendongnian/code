    public void IClockThread()
    {
        txtStatus.BeginInvoke((Action)(() => txtStatus.Text = "Thread for IClock Starts......" + Environment.NewLine));
        for (int i = 0; i < IclockDetails.Length; i++)
            Task.Run(() => ConnectMachineIClock(IclockDetails[i].IpAddress));
        txtStatus.BeginInvoke((Action)(() => txtStatus.Text += "Thread for IClock Ends............" + Environment.NewLine));
    }
