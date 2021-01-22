    const int WM_SETTINGCHANGE = 26;
    public void AddSettingChangeHook()
    {
      _settingChangeWatcher = new HwndSource(new HwndSourceParameters("WM_SETTINGSCHANGE watcher"));
      _settingChangeWatcher.AddHook((IntPtr hwnd, IntPtr msg, IntPtr wParam, IntPtr lParam, ref bool handled) =>
      {
        if((int)msg == WM_SETTINGCHANGE)
          Dispatcher.Invoke(DispatcherPriority.Input, new Action(() =>
          {
            LocallyDisableMousePointerVanish();
          });
      });
    }
