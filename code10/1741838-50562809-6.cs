    class MonitorDTO
    {
        public string Url{get;set;}
        public bool Success{get;set;}
        public string Message{get;set;}        
        public MonitorDTO(string ulr,bool success,string msg)
        {
         //...
        }
    }
    class MyMonitor
    {
        string[] _urls=url;
        public MyMonitor(string[] urls)
        {
          _urls=url;
        }   
        public Task Run(IProgress<MonitorDTO> progress)
        {
          while(true)
          {
             var ok=Task.Run(()=>CheckThatService(url));
             if(!ok)
             {
                _progress.Report(new MonitorDTO(ok,url,"some message");
             }
             await Task.Delay(1000);
          }
        }
    }
