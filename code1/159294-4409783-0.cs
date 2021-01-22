    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    private EventHandler _explicitEvent;
    public event EventHandler ExplicitEvent 
    {
       add 
       { 
           if (_explicitEvent == null) timer.Start();
           _explicitEvent += value; 
       } 
       remove 
       { 
          _explicitEvent -= value; 
          if (_explicitEvent == null) timer.Stop();
       }
    }
