        public MainWindow()
        {
            InitializeComponent();
            //Do use ThreadPool instead of this...
            Thread thread = new Thread(new ThreadStart(() => { GetWebsites(); }));
            thread.Start();
        }
        void GetWebsites()
        {
