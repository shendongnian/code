    void Main()
    {
    
    
        Timer timer = new Timer();
        timer.Tick += (o, e)
           {
               Queue syncQueue = Queue.Synchronized(MyService.queue);
               while(syncQueue.Count > 0)
               {
                    Message message = syncQueue.Dequeue() as Message;
                    WriteMessageToXMLFile(message);
               }
               timer.Start();
           };
        timer.Start();
    
        //Or whatever you do here
        StartupService();
    }
