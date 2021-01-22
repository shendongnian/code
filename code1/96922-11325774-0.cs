    public MainWindow()
        {
            InitializeComponent();
       
            #region initialise FileSystemWatcher
            FileSystemWatcher watch = new FileSystemWatcher();
            watch.Path = folder;
            watch.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            watch.Filter = ext;
            watch.Changed += new FileSystemEventHandler(OnChanged);
            watch.Created += new FileSystemEventHandler(OnChanged);
            watch.EnableRaisingEvents = true;
            #endregion
            
        }
     private void OnChanged(object source, FileSystemEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)delegate
            {
              // do your work here. If this work needs more time than it can be processed, not the filesystembuffer overflows but your application will block. In this case try to improve performance here.
            }, System.Windows.Threading.DispatcherPriority.Normal);
        }
