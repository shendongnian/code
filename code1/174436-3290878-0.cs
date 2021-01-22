    class MyForm
    {
        static void Main()
        {
            new Thread(delegate
                {
                    AppInitialize();
                })
                {
                    IsBackground = true
                }
                .Start();
            Application.Run(new MyForm());
        }
        static void AppInitialize()
        {
           // load app-wide resources, services, etc
        }
        public MyForm()
        {
            InitializeComponent();
            ThreadPool.QueueUserWorkItem(
                delegate
                {
                    InitializeServices();
                });
        }
        void InitializeServices()
        {
            // load up stuff the Form will need after loading/first rendering
        }
    }
    
