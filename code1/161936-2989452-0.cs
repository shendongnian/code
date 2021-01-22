    static int _counter;
            System.Timers.Timer _timer = new System.Timers.Timer(1000);
            Stopwatch sw;
            public Form1()
            {
                InitializeComponent();           
                _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
                _timer.Start();            
                sw = Stopwatch.StartNew();
            }
    
            void _timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                Console.WriteLine(sw.ElapsedMilliseconds);          
                _counter++;
                if (_counter == 20)
                    _timer.Stop();            
                sw.Reset();
                sw.Start();
            }
