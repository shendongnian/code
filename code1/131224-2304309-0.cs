    private void Application_Startup(object sender, StartupEventArgs e)
    {
        LoadConverters();
    }
    
    private void LoadConverters()
    {
        foreach(var t in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (t.GetInterfaces().Any(i => i.Name == "IValueConverter"))
            {
                Resources.Add(t.Name, Activator.CreateInstance(t));
            }
        }
    }
