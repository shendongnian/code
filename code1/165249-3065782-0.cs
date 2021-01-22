    private bool _performKilling;
    private object _lockObject = new object();
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
         while(true)
         {
    
             if (_performKilling)
             {
                 //Kill zombies
             }
             else
             { //We pause until we are woken up so as not to consume cycles
                 Monitor.Wait(_lockObject);
             }
         }
    }
    
    private void StartKilling()
    {
        _performKilling = true;
        Monitor.Pulse(_lockObject);
    }
    
    private void StopAllThatKilling()
    {
        _performKilling = false;
    ]
