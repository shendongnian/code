    string CaptureTime;
    string SaveFormat;
    public YourType()
    {
        DateTime now = DateTime.Now;
        CaptureTime = now.Month + "-" + now.Day + "-" + now.Year + "-" + 
            now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString();
        SaveFormat = Properties.Settings.Default.SaveFolder + 
            "Screenshot (" + CaptureTime + ")." + 
            Properties.Settings.Default.ImageFormat;
    }
