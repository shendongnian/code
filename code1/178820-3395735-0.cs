    private void Application_Startup(object sender, StartupEventArgs e)
    {
      Resources.Add("DefaultCulture", System.Globalization.CultureInfo.CurrentCulture);
      this.RootVisual = new MainPage();
    }
