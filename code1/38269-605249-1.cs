    class lanmessenger
    {
        TcpListener t = new TcpListener(5555);  // ok to initialize like this
    
        public lanmessenger
        {
            InitializeComponent();
            t.Start();  // put it here
        }    
    }
