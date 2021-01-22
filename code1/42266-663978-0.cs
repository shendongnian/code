    public App() 
    {
      Startup += App_Startup
    }
    
    public void App_Startup(object sender, RoutedEventArgs e)
    {
      while (true)
      {
        Thread.Sleep(1000);
        MainWindow = new Window();
        MainWindow.Show();
        Thread.Sleep(1000);
        MainWindow.Close();
      }
    }
