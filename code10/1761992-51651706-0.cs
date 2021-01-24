    private void timer1_Tick(object sender, EventArgs e) {
        label1.Text = IdleCounter.NextValue().ToString("N0");
        double total = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        var used = 1024.0 * 1024.0 * RamCounter.NextValue();
        label2.Text = (100.0 * (total - used) / total).ToString("N0");
    }
