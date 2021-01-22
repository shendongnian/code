            private PerformanceCounter cpuCounter;
            private PerformanceCounter ramCounter;
            public Form1()
            {
                InitializeComponent();
                InitialiseCPUCounter();
                InitializeRAMCounter();
                updateTimer.Start();
            }
     
            private void updateTimer_Tick(object sender, EventArgs e)
            {
                this.textBox1.Text = "CPU Usage: " +
                Convert.ToInt32(cpuCounter.NextValue()).ToString() +
                "%";
     
                this.textBox2.Text = Convert.ToInt32(ramCounter.NextValue()).ToString()+"Mb";
            }
     
            private void Form1_Load(object sender, EventArgs e)
            {
     
            }
     
            private void InitialiseCPUCounter()
            {
                cpuCounter = new PerformanceCounter(
                "Processor",
                "% Processor Time",
                "_Total",
                true
                );
            }
     
            private void InitializeRAMCounter()
            {
                ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
             
            }
