        public MainWindow()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(() => { GetWebsites(); }));
            thread.Start();
        }
        [MTAThread]
        void GetWebsites()
        {
