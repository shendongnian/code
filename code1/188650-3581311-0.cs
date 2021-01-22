    if (e.Button == MouseButtons.Left)
    {
       MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", 
                BindingFlags.Instance |BindingFlags.NonPublic);
        mi.Invoke(taskbarIcon, null);
    }
