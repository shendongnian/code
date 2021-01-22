    public void Application_Start(Object sender, EventArgs e)
    {
      ...
      Application["ApplicationStartTime"] = DateTime.Now.ToString("o");
    }
