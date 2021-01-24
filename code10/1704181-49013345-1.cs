    public static Settings Instance
    {
        get
        {
            if (AppWindow == null)
            {
                AppWindow = new Settings();
                //attach the event handler
                AppWindow.Closing += AppWindow_Closing;
            }
            return AppWindow;
        }
    }
    private static async void AppWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;
        //call the async method
        bool close = await AppWindow.CheckSettings();
        if (close)
        {
            AppWindow win = (AppWindow)sender;
            //detach the event handler
            AppWindow.Closing -= AppWindow_Closing;
            //...and close the window immediately
            win.Close();
            AppWindow = null;
        }
    }
