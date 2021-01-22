    if (ShouldRestartApp)
    {
       Properties.Settings.Default.IsRestarting = true;
       Properties.Settings.Default.Save();
       Application.Restart();
    }
