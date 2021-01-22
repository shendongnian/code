    public class Foo
    {
       private FileSystemWatcher _fs;
    
       private volatile bool _stopped = false;
    
       public Foo()
       {
           _fs = new FileSystemWatcher();
           ...
       }
    
       public void Start()
       {
           _stopped = false;
           Thread t = new Thread (new ThreadStart(DoWork));
           t.Start();
       }
    
       private void DoWork()
       {
           while( !_stopped )
           {
               Thread.Sleep(1);
           }
       }
    
       public void Stop()
       {
           _stopped = true;
       }
    
    }
