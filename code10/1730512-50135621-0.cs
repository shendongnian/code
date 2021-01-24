    private void timer_Tick(object sender, EventArgs e)
    {
        MMDevice device = null;
        if (comboBox1.SelectedItem != null)
            device = (MMDevice)comboBox1.SelectedItem;
        else
            device = GetDefaultAudioEndpoint();
        if (device != null)
            progressBar1.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
        else
            progressBar1.Value = 0;
    }
    public MMDevice GetDefaultAudioEndpoint()
    {
        MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
    }
 
