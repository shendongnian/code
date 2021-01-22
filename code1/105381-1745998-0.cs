    public interface IMainAppWindow
    {
       event EventHandler Closed;
    }
    
    // version 1 main window
    public MainForm : Form , IMainAppWindow
    {
    
    }
    
    // version 2 main window
    public MainWindow : Window , IMainAppWindow
    {
      event EventHandler Closed;
    
      public void OnClosed(object sender,RoutedEventArgs e)
      {
        if(Closed != null)
        {
          Closed(this,e);
        }
      }
    }
