    public static Settings Instance
    {
        get
        {
            if (AppWindow == null)
            {
                AppWindow = new Settings();
                AppWindow.Closing += AppWindow_Closing;
            }
            return AppWindow;
        }
    }
    private static async void AppWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;
        bool close = await AppWindow.CheckSettings();
        if (close)
        {
            AppWindow win = (AppWindow)sender;
            AppWindow.Closing -= AppWindow_Closing;
            win.Close();
            AppWindow = null;
        }
    }
