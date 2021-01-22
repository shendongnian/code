    static bool isProcessed = false;
    static void Main(string[] args)
    {
        Worker worker = new Worker();
        worker.WorkCompleted += PostProcess;
        worker.DoWork();
        while(!isProcessed)
        {
          System.Threading.Thread.Sleep(-1);
        }
    }
    
    static void PostProcess(object sender, EventArgs e) 
    { 
       // Cannot see this happening 
       isProcessed=true;
    }
