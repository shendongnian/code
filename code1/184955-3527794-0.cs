    static void Main(string[] args)
    {
       BackgroundWorker worker = new BackgroundWorker();
       //DoWork is a delegate, where you can add tasks
       worker.DoWork += (sender, e) =>
          { 
                //blabla
          };
       worker.DoWork += (sender, e) =>
          {
                //blabla
          };
       worker.RunWorkerCompleted += (sender, e) =>
          {
               var IfYouWantTheResult = e.Result;
               //maybe notify others here
          };
       worker.RunWorkerAsync();
       //you can cancel the worker/report its progress by its methods.
    }
           
