    using System.Threading;
    
    .....
    
    Thread _t = null;
    void StartProcedure()
    {
      _t = new Thread(new ThreadStart(this.StartProc));
      _t.IsBackground = false;//If I remember correctly, this is the default value. 
      _t.Start();
    }
    
    bool ProcedureIsRunning
    {
     get { return _t.IsRunning; } //Maybe it's IsActive. Can't remember. 
    }
    
    void StartProc(object param)
    {
      //your logic here.. could also do this as an anonymous method. Broke it out to keep it simple. 
    }
