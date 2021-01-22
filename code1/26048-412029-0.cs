            public Form1()
            {
                InitializeComponent();
                timer.Interval = 1000;
                timer.Tick += new EventHandler(timer_Tick);
            }
