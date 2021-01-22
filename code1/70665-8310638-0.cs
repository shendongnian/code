    public MainWindow()
        {
            InitializeComponent();
            ComponentDispatcher.ThreadIdle += new System.EventHandler(ComponentDispatcher_ThreadIdle);
        }
    void ComponentDispatcher_ThreadIdle(object sender, EventArgs e)
        {
            //do your idle stuff here
        }
