    Application.Idle += Initialize;
    Application.Run();
    ...
    
    private void Initialize (object sender, EventArgs e) 
    { 
      Application.Idle -= Initialize; 
      _hook = new KeyboardHook();
      
      // this must be performed from the thread running Application.Run!
      // do not move it out of this event handler
      _hook.RegisterHotKey (...);      
    }
