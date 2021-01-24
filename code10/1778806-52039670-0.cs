    private Timer timer; 
    public void InitTimer()
    {
        timer= new Timer();
        timer.Elapsed += OnTimerTick;
        timer.Interval = 1000; // Remember this is milliseconds
        timer.Start();
    }
    
    private void OnTimerTick(object sender, ElapsedEventArgs e)
    {
        string text = System.IO.File.ReadAllText(@"path\query.txt");              
        OracleCommand command = new OracleCommand(text, conn);               
        OracleDataReader data = command.ExecuteReader();
        while (data.Read())
        ...
    }
