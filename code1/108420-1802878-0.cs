    public MainPage()
     {
         InitializeComponent();
         Loaded += new RoutedEventHandler(MainPage_Loaded);   
         // wire up the various Drop events
         InstallButton.Drop += new DragEventHandler(InstallButton_Drop);
         InstallButton.DragOver += new DragEventHandler(InstallButton_DragOver);
         InstallButton.DragEnter += new DragEventHandler(InstallButton_DragEnter);
         InstallButton.DragLeave += new DragEventHandler(InstallButton_DragLeave);
     }
    
     void InstallButton_Drop(object sender, DragEventArgs e)
     {
         IDataObject foo = e.Data; // do something with data
     }
