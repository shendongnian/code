    public class Window1 : Window
    {
      // Capsulate DataContext to MainViewModel
      public MainViewModel MainViewModel
      {
        get => this.DataContext as MainViewModel;
        set => this.DataContext = value;
      }
      public Window1()
      {
        this.InitializeComponents();
        // Create new MainViewModel and set DataContext (in property)
        this.MainViewModel = new MainViewModel();
      }
      private void OpenWindow2()
      {
        // pass current MainViewModel to Window2
        var window2 = new Window2(this.MainViewModel);
        window2.Show();
      }
    }
    public class Window2 : Window
    {
      public MainViewModel MainViewModel
      {
        get => this.DataContext as MainViewModel;
        set => this.DataContext = value;
      }
      public Window2(MainViewModel mainViewModel)
      {
        // set MainViewModel to instance passed from MainWindow
        this.InitializeComponents();
        this.MainViewModel = mainViewModel();
      }
    }
