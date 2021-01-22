    private TcpClient client;
    private Queue<string> commands = new Queue<string>();
    private AutoResetEvent resume = new AutoResetEvent(false);
    
    public void Add(string cmd)
    {
      lock(commands) { commands.Enqueue(cmd); }
      resume.Set();
       
    }
    
    private void ThreadRun() // this method runs on a different thread
    {
       while(!quit.WaitOne(0,true))
       {
          resume.WaitOne();
          string command;
          lock(commands) { command = commands.Dequeue(); }
          Process(command);
    
       }
    
       
    }
