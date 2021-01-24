    class Utils
    {
        readonly MainWindow mainWindow;
        public Utils(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
        }
    }
    class MainWindow
    {
        readonly Utils utils;
        public MainWindow()
        {
            InitilaizeComponent();
            utils = new Utils(this);
        }
    }
