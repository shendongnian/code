    public void IClockThread()
    {
        txtStatus.BeginInvoke((Action)(() => txtStatus.Text = "Thread for IClock Starts......" + Environment.NewLine));
        Task.Run(() =>
        {
            Parallel.For(0, IclockDetails.Count, (i) =>
            {
                ConnectMachineIClock(IclockDetails[i].IpAddress);
            });
        });
        txtStatus.BeginInvoke((Action)(() => txtStatus.Text += "Thread for IClock Ends............" + Environment.NewLine));
    }
