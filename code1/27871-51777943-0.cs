    using Microsoft.Win32;
    SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
    static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
    {
         MessageBox.Show("Resolution Change.");
    }
