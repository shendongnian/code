    NotifyIcon icon = new NotifyIcon();
    icon.Icon = new System.Drawing.Icon("icon.ico");
    icon.Visible = true;
    icon.DoubleClick += Icon_DoubleClick;
    icon.ShowBalloonTip(2000, "Hello", "This is Tip", ToolTipIcon.Info);
