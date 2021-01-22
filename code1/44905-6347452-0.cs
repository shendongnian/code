    private System.Threading.Timer _timer;    
    
    public void Run() {
      //setup filewatcher
      _timer = new System.Threading.Timer(new TimerCallback(OnFileChange), (object) null, -1, -1);
    }
    
    private void OnFileChange(object state)
    {
      try 
      {
        //handle files
      }
      catch (Exception ex) 
      {
        //log exception
        _timer.Change(500, -1);
      }
