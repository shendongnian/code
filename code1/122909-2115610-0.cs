        public SocketClient() 
        { 
            InitializeComponent(); 
            var timer = new System.Windows.Forms.Timer(); 
            timer.Tick += new EventHandler(TimerOnTick); 
            timer.Interval = 1000; 
            timer.Start(); 
        } 
