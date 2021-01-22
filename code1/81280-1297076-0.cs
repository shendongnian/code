    private void SetUpTrayIcon()
    {
        notifyIcon = new System.Windows.Forms.NotifyIcon();
        notifyIcon.BalloonTipText = "Ballon minimize text";
        notifyIcon.BalloonTipTitle = "Ballon minimize title";
        notifyIcon.Text = "Icon hover text";
        notifyIcon.Icon = new  System.Drawing.Icon(
                   System.Reflection.Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream("MyIcon.ico"));
        notifyIcon.Click += new EventHandler(HandlerToMaximiseOnClick);
    }
